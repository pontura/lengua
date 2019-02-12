using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivePortal : InteractiveObject
{
	public Room.types roomType;
	public Vector2 newPos;

	public override void OnCharacterReachMe()
	{ 
		Events.ChangeRoom (roomType, newPos );
	}
}
