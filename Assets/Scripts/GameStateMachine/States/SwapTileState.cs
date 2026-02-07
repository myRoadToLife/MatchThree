using System;
using System.Threading;
using Animations;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Game.Tiles;
using MatchTiles;
using UnityEngine;
using Grid = Game.GridSystem.Grid;

namespace GameStateMachine.States
{
    public class SwapTileState : IState, IDisposable
    {
        private CancellationTokenSource _cts;
        private Grid _grid;
        private IStateSwitcher _stateSwitcher;
        private IAnimation _animation;
        private MatchFinder _matchFinder;

        public SwapTileState(Grid grid, IStateSwitcher stateSwitcher, IAnimation animation, MatchFinder matchFinder)
        {
            _grid = grid;
            _stateSwitcher = stateSwitcher;
            _animation = animation;
            _matchFinder = matchFinder;
        }

        public void Dispose() => _cts?.Dispose();

        public async void Enter()
        {
            _cts = new CancellationTokenSource();
            //play sound

            await SwapTiles(_grid.CurrentPosition, _grid.TargetPosition);

            if (_matchFinder.CheckBoardForMatches(_grid) == false)
            {
                //play sound no match
                await SwapTiles(_grid.TargetPosition, _grid.CurrentPosition);
                _stateSwitcher.SwitchState<PlayerTurnState>();
            }
            else
            {
                //play sound match
                //spend move
                _stateSwitcher.SwitchState<RemoveTileState>();
            }
        }

        public void Exit() => _cts?.Cancel();

        private async UniTask SwapTiles(Vector2Int currentPos, Vector2Int targetPos)
        {
            var currentTile = _grid.GetValue(currentPos.x, currentPos.y);
            var targetTile = _grid.GetValue(targetPos.x, targetPos.y);

            MoveAnimation(currentTile, targetPos);
            MoveAnimation(targetTile, currentPos);

            _grid.SetValue(currentPos.x, currentPos.y, targetTile);
            _grid.SetValue(targetPos.x, targetPos.y, currentTile);

            await UniTask.Delay(TimeSpan.FromSeconds(0.5f), _cts.IsCancellationRequested);
        }

        private void MoveAnimation(Tile tileToMove, Vector2Int position) =>
            _animation.MoveTile(tileToMove, _grid.GridToWorld(position.x, position.y), Ease.OutCubic);
    }
}