using System.Collections.Generic;
using Animations;
using Game.Board;
using Game.GridSystem;
using GameStateMachine.States;
using MatchTiles;

namespace GameStateMachine
{
    public class StateMachine : IStateSwitcher
    {
        private List<IState> _states;
        private IState _currentState;
        private GameBoard _gameBoard;
        private Grid _grid;
        private IAnimation _animation;
        private MatchFinder _matchFinder;

        public StateMachine(GameBoard gameBoard, Grid grid, IAnimation animation, MatchFinder matchFinder)
        {
            _gameBoard = gameBoard;
            _grid = grid;
            _animation = animation;
            _matchFinder = matchFinder;
            
            _states = new List<IState>()
            {
                new PrepareState(this, _gameBoard),
                new PlayerTurnState(_grid, this, _animation),
                new SwapTileState(_grid, this, _animation, _matchFinder),
                new RemoveTileState(_grid, this, _animation, _matchFinder),
                new RefillGridState()
            };
            
            _currentState = _states[0];
            _currentState.Enter();
        }

        public void SwitchState<T>() where T : IState
        {
            var state = _states.Find(state => state is T);
            
            _currentState.Exit();
            _currentState = state;
            _currentState?.Enter();
            
        }
    }
}