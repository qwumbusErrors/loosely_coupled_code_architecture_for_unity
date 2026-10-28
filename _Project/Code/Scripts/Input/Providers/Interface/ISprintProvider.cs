using System;
using UnityEngine;

public interface ISprintProvider
{
	public bool IsSprint { get; }
	public event Action<bool> OnChanged; 
}