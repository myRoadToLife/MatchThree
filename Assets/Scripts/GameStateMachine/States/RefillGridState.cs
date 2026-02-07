using System;
using UnityEngine;

namespace GameStateMachine.States
{
    public class RefillGridState : IState, IDisposable
    {
        public void Dispose()
        {
        }

        public void Enter()
        {
            Debug.Log("Start RefillGridState");
        }

        public void Exit()
        {
        }
    }
}