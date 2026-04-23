using Ksy.Utility;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Ksy.Network.Client
{
    public abstract class Session
    {
        private Socket _socket;
        private int _disconnected = 0;
        private ReceiveBuffer _receiveBuffer;

        private object _lock = new object();
        private Queue<ArraySegment<byte>> _sendQueue = new Queue<ArraySegment<byte>>();
        private List<ArraySegment<byte>> _pendingList = new List<ArraySegment<byte>>();
        private SocketAsyncEventArgs _sendArgs = new SocketAsyncEventArgs();
        private SocketAsyncEventArgs _receiveArgs = new SocketAsyncEventArgs();

        public abstract void OnConnected(EndPoint endPoint);
        public abstract int OnReceive(ArraySegment<byte> buffer);
        public abstract void OnSend(int numOfBytes);
        public abstract void OnDisconnected(EndPoint endPoint);

        private void Clear()
        {
            _sendQueue.Clear();
            _pendingList.Clear();
        }

        public void Start(Socket socket)
        {
            _socket = socket;

            _receiveArgs.Completed += new EventHandler<SocketAsyncEventArgs>(OnReceiveCompleted);
            _sendArgs.Completed += new EventHandler<SocketAsyncEventArgs>(OnSendCompleted);

            RegisterReceive();
        }

        public void Send(List<ArraySegment<byte>> sendBufferList)
        {
            if (sendBufferList.Count == 0)
                return;

            lock (_lock)
            {
                foreach (ArraySegment<byte> sendBuffer in sendBufferList)
                    _sendQueue.Enqueue(sendBuffer);

                if (_pendingList.Count == 0)
                    RegisterSend();
            }
        }

        public void Send(ArraySegment<byte> sendBuffer)
        {
            lock (_lock)
            {
                _sendQueue.Enqueue(sendBuffer);
                if (_pendingList.Count == 0)
                    RegisterSend();
            }
        }

        public void Disconnect()
        {
            if (Interlocked.Exchange(ref _disconnected, 1) == 1)
                return;

            OnDisconnected(_socket.RemoteEndPoint);
            _receiveArgs.Dispose();
            _sendArgs.Dispose();
            _socket.Shutdown(SocketShutdown.Both);
            _socket.Close();
            Clear();
        }

        private void RegisterSend()
        {
            if (_disconnected == 1)
                return;

            while (_sendQueue.Count > 0)
            {
                ArraySegment<byte> buffer = _sendQueue.Dequeue();
                _pendingList.Add(buffer);
            }
            _sendArgs.BufferList = _pendingList;

            try
            {
                bool pending = _socket.SendAsync(_sendArgs);
                if (pending == false)
                    OnSendCompleted(null, _sendArgs);
            }
            catch (Exception excep)
            {
                Console.WriteLine($"RegisterSend Failed {excep}");
            }
        }

        void OnSendCompleted(object sender, SocketAsyncEventArgs args)
        {
            lock (_lock)
            {
                if (args.BytesTransferred > 0 && args.SocketError == SocketError.Success)
                {
                    try
                    {
                        _sendArgs.BufferList = null;
                        _pendingList.Clear();

                        OnSend(_sendArgs.BytesTransferred);

                        if (_sendQueue.Count > 0)
                            RegisterSend();
                    }
                    catch (Exception excep)
                    {
                        Console.WriteLine($"OnSendCompleted Failed {excep}");
                    }
                }
                else
                {
                    Disconnect();
                }
            }
        }

        void RegisterReceive()
        {
            if (_disconnected == 1)
                return;

            _receiveBuffer.Clean();
            ArraySegment<byte> segment = _receiveBuffer.WriteSegment;
            _receiveArgs.SetBuffer(segment.Array, segment.Offset, segment.Count);

            try
            {
                bool pending = _socket.ReceiveAsync(_receiveArgs);
                if (pending == false)
                    OnReceiveCompleted(null, _receiveArgs);
            }
            catch (Exception excep)
            {
                // 실패시 예외 처리
                CustomLog.Log($"RegisterReceive Failed {excep}");
            }
        }

        void OnReceiveCompleted(object sender, SocketAsyncEventArgs args)
        {
            if (args.BytesTransferred > 0 && args.SocketError == SocketError.Success)
            {
                try
                {
                    if (_receiveBuffer.OnWrite(args.BytesTransferred) == false)
                    {
                        Disconnect();
                        return;
                    }

                    int processLen = OnReceive(_receiveBuffer.ReadSegment);
                    if (processLen < 0 || _receiveBuffer.DataSize < processLen)
                    {
                        Disconnect();
                        return;
                    }

                    if (_receiveBuffer.OnRead(processLen) == false)
                    {
                        Disconnect();
                        return;
                    }

                    RegisterReceive();
                }
                catch (Exception excep)
                {
                    CustomLog.Log($"OnReceiveCompleted Failed {excep}");
                }
            }
            else
            {
                Disconnect();
            }
        }
    }
}
