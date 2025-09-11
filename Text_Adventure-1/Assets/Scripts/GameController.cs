using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text displayText;
    
    [HideInInspector] public RoomNavigation _roomNavigation;
    [HideInInspector] public List<string> interactionDescriptionsInRoom = new List<string>();

    List<string> actionLog = new List<string>();

    private void Awake()
    {
        _roomNavigation = GetComponent<RoomNavigation>();
    }

    private void Start()
    {
        DisplayRoomText();
        DisplayLogggedText();
    }

    public void DisplayLogggedText()
    {
        string logAsText = string.Join("\n" , actionLog.ToArray()); 

        displayText.text = logAsText;
    }
    public void DisplayRoomText()
    {
        UnpackRoom();

        string jointInteractionDescriptions = string.Join("\n" , interactionDescriptionsInRoom.ToArray());
        string combinedText = _roomNavigation.currentRoom.roomDescription + "\n" + jointInteractionDescriptions;

        LogStringWithReturn(combinedText);
    }

    private void UnpackRoom()
    {
        _roomNavigation.UnpackExitsInRoom();
    }
    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");
    }
}
