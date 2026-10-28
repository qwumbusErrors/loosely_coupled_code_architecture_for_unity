using System;
using UnityEngine.InputSystem;

public class PlayerInputService : IPlayerInputService, IDisposable
{
	private readonly GameAction _gameInputMap;
	public GameAction Actions => _gameInputMap;

	public PlayerInputService()
    {
        _gameInputMap = new GameAction();
        _gameInputMap.Enable();
    }

    public void Dispose()
    {
        _gameInputMap.Disable();
        _gameInputMap.Dispose();
    }
}