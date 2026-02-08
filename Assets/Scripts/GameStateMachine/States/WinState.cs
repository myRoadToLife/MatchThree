using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

namespace GameStateMachine.States
{
    public class WinState : IState
    {
        public void Enter()
        {
            Debug.Log("Ты выиграл!!!");
        }

        public void Exit()
        {
        }
    }
}