using System;
using System.Numerics;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputReader : IDisposable
    {
        public event Action OnClicked;
        private Inputs _inputs;

        private InputAction _positionAction;
        private InputAction _clickAction;

        private bool _isClicking;

        public InputReader()
        {
            _inputs = new Inputs();
            _inputs.Player.Click.performed += OnClick;
        }

        public void EnableInputs(bool value)
        {
            if (value)
                _inputs.Player.Enable();
            else
                _inputs.Player.Disable();
        }

        public Vector2 Position() => _inputs.Player.Select.ReadValue<Vector2>();

        public void Dispose() => _inputs.Player.Click.performed -= OnClick;

        private void OnClick(InputAction.CallbackContext context) => OnClicked?.Invoke();
    }
}