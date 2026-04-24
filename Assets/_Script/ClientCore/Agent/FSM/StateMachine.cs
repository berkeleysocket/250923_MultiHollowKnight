using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ksy.AgentSystem.FSM
{
    public class StateMachine : MonoBehaviour
    {
        public AgentState CurrentState { get; private set; }

        private Dictionary<int, AgentState> _stateDict;

        public StateMachine(Agent agent, StateSO[] stateList)
        {
            _stateDict = new Dictionary<int, AgentState>();

            foreach (StateSO stateData in stateList)
            {
                //GetType 메서드를 통해 현재 인스턴스의 정보를 가져올 수도 있지만,
                //전체 형식에서 이름을 통해 찾아올 수도 있다.
                Type type = Type.GetType(stateData.className);
                Debug.Assert(type != null, $"Finding type is null {stateData.className}");
                AgentState agentState = Activator.CreateInstance(type, agent, stateData.stateParam.ParamHash) as AgentState;

                _stateDict.Add(stateData.assetName, agentState);
            }
        }
        public void ChangeState(int newStateIndex, float transitionDuration = 0.1f)
        {
            CurrentState?.Exit();
            AgentState newState = _stateDict.GetValueOrDefault(newStateIndex);
            Debug.Assert(newState != null, $"State is null: {newStateIndex}");

            CurrentState = newState;
            CurrentState.Enter(transitionDuration);
        }
        public void UpdateMachine()
        {
            CurrentState?.Update();
        }
    }
}
