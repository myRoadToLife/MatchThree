using System;
using System.Collections.Generic;
using System.Threading;
using Animations;
using Cysharp.Threading.Tasks;
using Game.GridSystem;
using Game.Score;
using Game.Tiles;
using MatchTiles;

namespace GameStateMachine.States
{
    public class RemoveTileState : IState, IDisposable
    {
        private CancellationTokenSource _cts;
        private Grid _grid;
        private IStateSwitcher _stateSwitcher;
        private IAnimation _animation;
        private MatchFinder _matchFinder;
        private GameProgress _gameProgress;
        private ScoreCalculator _scoreCalculator;

        public RemoveTileState(Grid grid,
            IStateSwitcher stateSwitcher,
            IAnimation animation,
            MatchFinder matchFinder,
            GameProgress gameProgress,
            ScoreCalculator scoreCalculator)
        {
            _grid = grid;
            _stateSwitcher = stateSwitcher;
            _animation = animation;
            _matchFinder = matchFinder;
            _gameProgress = gameProgress;
            _scoreCalculator = scoreCalculator;
        }

        public void Dispose() => _cts?.Dispose();

        public async void Enter()
        {
            _cts = new CancellationTokenSource();
            _scoreCalculator.CalculateScoreToAdd(_matchFinder.CurrentMatchResult.MatchDirection);
            await RemoveTiles(_matchFinder.TilesToRemove, _grid);
            _stateSwitcher.SwitchState<RefillGridState>();
        }

        public void Exit()
        {
            _matchFinder.ClearTilesToRemove();
            _cts?.Cancel();
        }

        private async UniTask RemoveTiles(List<Tile> tilesToRemove, Grid grid)
        {
            foreach (var tile in tilesToRemove)
            {
                //playsound

                var pos = grid.WorldToGreed(tile.transform.position);
                grid.SetValue(pos.x, pos.y, null);

                await _animation.HideTile(tile.gameObject);
                //FX
            }
            
            _cts.Cancel();
        }
    }
}