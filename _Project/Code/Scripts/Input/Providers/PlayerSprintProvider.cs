using System;
using UnityEngine.InputSystem;

public class PlayerSprintProvider : ISprintProvider, IDisposable
{
    private readonly InputAction _action;

    public bool IsSprinting { get; private set; }
    public event Action<bool> OnChanged;

    public PlayerSprintProvider(InputAction action)
    {
        _action = action ?? throw new ArgumentNullException(nameof(action));
        _action.started  += OnStarted;
        _action.canceled += OnCanceled;
    }

    private void OnStarted(InputAction.CallbackContext _)  => SetSprint(true);
    private void OnCanceled(InputAction.CallbackContext _) => SetSprint(false);

    private void SetSprint(bool value)
    {
        if (IsSprinting == value) return;
        
        IsSprinting = value;
        OnChanged?.Invoke(value);
    }

    public void Dispose()
    {
        _action.started  -= OnStarted;
        _action.canceled -= OnCanceled;
    }
}