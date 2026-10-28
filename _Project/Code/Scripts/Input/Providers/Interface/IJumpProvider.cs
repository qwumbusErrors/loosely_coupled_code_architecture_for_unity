using System;
using UnityEngine;

public interface IJumpProvider
{
	public bool IsJump { get; }
	public event Action<bool> OnChanged; 
}