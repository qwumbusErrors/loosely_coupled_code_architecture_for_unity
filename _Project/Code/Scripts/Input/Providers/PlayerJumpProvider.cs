using System;
using UnityEngine.InputSystem;

public class PlayerJumpProvider : IJumpProvider, IDisposable
{
	private readonly InputAction _action;

	public bool IsJump { get; private set; }
	public event Action<bool> OnChanged;

	public PlayerJumpProvider(InputAction action)
	{
		_action = action ?? throw new ArgumentNullException(nameof(action));

		_action.started  += OnStarted;
        _action.canceled += OnCanceled;
	}

	private void OnStarted(InputAction.CallbackContext _) => SetJump(true);
    private void OnCanceled(InputAction.CallbackContext _) => SetJump(false);

    private void SetJump(bool value)
    {
        if (IsJump == value) return;
        
        IsJump = value;
        OnChanged?.Invoke(value);
    }

	public void Dispose()
    {
    	_action.started  -= OnStarted;
        _action.canceled -= OnCanceled;
    }
}