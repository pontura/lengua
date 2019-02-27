using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsManager : MonoBehaviour {

	public Character character;
	public CutscenesUI cutscenesUI;
	public Room.types roomType;
	public Room[] rooms;
	Room room;
	public Transform container;

	void Start()
	{
		Events.ChangeRoom += ChangeRoom;
		ChangeRoom (roomType, new Vector2(1,2));
	}
	void ChangeRoom(Room.types type, Vector2 pos)
	{
		
		Utils.RemoveAllChildsIn(container);

		Room newRoom = rooms [0];
		switch (type)
		{
		case Room.types.ESCRITORIO:
			newRoom = rooms [0];
			break;
		case Room.types.BIBLIOTECA:
			newRoom = rooms [1];
			break;
		case Room.types.MAPOTECA:
			newRoom = rooms [2];
			break;
		case Room.types.PATIO:
			newRoom = rooms [3];
			break;
		case Room.types.LAB:
			newRoom = rooms [4];
			break;
		}
		
		room = Instantiate (newRoom);
		room.transform.SetParent (container);
		room.transform.localPosition = Vector3.zero;
		room.Init (this);
		Events.OnEnterNewRoom (room);
	}

}
