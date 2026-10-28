using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveProvider : IMoveProvider, IDisposable
{
	private readonly InputAction _action;

	public Vector2 MoveVector {	get; private set; }
	public event Action<Vector2> OnChanged;

	public PlayerMoveProvider(InputAction action)
	{
		_action = action ?? throw new ArgumentNullException(nameof(action));

		_action.performed += InputChanged;
        _action.canceled  += InputChanged;
	}

	private void InputChanged(InputAction.CallbackContext context)
	{
		var direction = context.canceled ? Vector2.zero : context.ReadValue<Vector2>();

		if (direction == MoveVector) return;

		MoveVector = direction;
        OnChanged?.Invoke(direction);
	}

	public void Dispose()
    {
        _action.performed -= InputChanged;
        _action.canceled  -= InputChanged;
    }
}