using UnityEngine;

namespace GameStateMachine.States
{
    public class LossState : IState
    {
        public void Enter()
        {
            Debug.Log("Ты проиграл!!!");
        }

        public void Exit()
        {
        }
    }
}