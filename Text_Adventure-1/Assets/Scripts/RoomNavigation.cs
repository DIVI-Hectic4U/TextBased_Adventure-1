using System.Collections.Generic;
using System.Transactions;
using UnityEditor;
using UnityEngine;

public class RoomNavigation : MonoBehaviour
{
    public Room currentRoom;

    Dictionary<string,Room> exitDictionary = new Dictionary<string,Room>();

    private GameController controller;

    private void Awake()
    {
        controller = GetComponent<GameController>();
    }

    public void UnpackExitsInRoom()
    {
        for(int i = 0; i < currentRoom.exits.Length; i++)
        {
            exitDictionary.Add(currentRoom.exits[i].keyString, currentRoom.exits[i].valueRoom);
            controller.interactionDescriptionsInRoom.Add(currentRoom.exits[i].exitDescription);
        }
    }

    public void AttemptToChangeRooms(string RoomNoun)
    {
        if (exitDictionary.ContainsKey(RoomNoun))
        {
            currentRoom = exitDictionary[RoomNoun];
            controller.LogStringWithReturn("You head off the " +  RoomNoun);
            controller.DisplayRoomText();
        }
        else
        {
            controller.LogStringWithReturn("There is no path to the " + RoomNoun);
        }
    }

    public void ClearExits()
    {
        exitDictionary.Clear();
    }
}
