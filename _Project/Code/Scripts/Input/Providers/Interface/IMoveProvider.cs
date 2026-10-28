using System;
using UnityEngine;

public interface IMoveProvider
{
	public Vector2 MoveVector {	get; }
	public event Action<Vector2> OnChanged;
}