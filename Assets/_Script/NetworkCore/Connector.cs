using Ksy.Utility;
using System;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

namespace Ksy.Network.Client
{
    public class Connector : MonoBehaviour
    {
        private Func<Session> _sessionFactory;
        public void Connect(IPEndPoint endPoint, Func<Session> sessionFactory, int count = 1)
        {
            Socket socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _sessionFactory = sessionFactory;

            SocketAsyncEventArgs args = new SocketAsyncEventArgs();
            args.Completed += OnConnectedCompleted;
            args.RemoteEndPoint = endPoint;
            args.UserToken = socket;

            RegisterConnect(args);
        }
        public void RegisterConnect(SocketAsyncEventArgs args)
        {
            Socket socket = args.UserToken as Socket;
            if (socket == null)
                return;

            bool pending = socket.ConnectAsync(args);
            if (pending == false)
                OnConnectedCompleted(null, args);
        }
        private void OnConnectedCompleted(object? sender, SocketAsyncEventArgs args)
        {
            if (args.SocketError == SocketError.Success)
            {
                Session session = _sessionFactory.Invoke();
                session.Start(args.ConnectSocket);
                session.OnConnected(args.RemoteEndPoint);
            }
            else
            {
                //실패 로직 처리
                CustomLog.Log($"OnConnectCompleted Fail: {args.SocketError}");

                if (args.UserToken is Socket socket)
                    socket.Close();
            }
            
            args.Dispose();
        }
    }
}

