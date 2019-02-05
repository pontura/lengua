using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsManager : MonoBehaviour {

	public Room[] rooms;
	public Room room;
	void Start()
	{
		Events.ChangeRoom += ChangeRoom;
	}
	public void ChangeRoom(Room.types type)
	{
		foreach (Room room in rooms)
			room.gameObject.SetActive (false);
		room = GetRoom (type);
		room.gameObject.SetActive (true);
	}
	Room GetRoom(Room.types type){
		foreach (Room room in rooms) {
			if (room.type == type)
				return room;
		}
		return null;
	}
}
