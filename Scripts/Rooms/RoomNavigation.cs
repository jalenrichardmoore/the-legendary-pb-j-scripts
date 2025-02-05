using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour
{
    // Dictionary of every exit in the current room and their associated keywords
    private Dictionary<string, Room> exitDictionary = new Dictionary<string, Room>();

    public Room currentRoom;                            // The room the player is in

    // Adds every exit in the room to 'exitDictionary'
    public void UnpackExitsInRoom()
    {
        // Loops through every exit in the current room
        for (int i = 0; i < currentRoom.roomExits.Length; i++)
        {
            // Loops through every keyword for each exit
            for (int j = 0; j < currentRoom.roomExits[i].keyStrings.Length; j++)
            {
                // Adds the current keyword and its associated exit to 'exitDictionary'
                exitDictionary.Add(currentRoom.roomExits[i].keyStrings[j], currentRoom.roomExits[i].valueRoom);
            }

            // Adds the exit's description to the list of descriptions for the room
            GameManager.gm.objectDescriptions.Add(currentRoom.roomExits[i].exitDescription);
        }
    }

    // Checks if the player can move to the given room and moves them if possible
    public void AttemptToChangeRoom(string keyWord)
    {
        // Checks if 'exitDictionary' has an entry for the specified exit
        if (exitDictionary.ContainsKey(keyWord))
        {
            // Moves the player to that exit and display's that room's information
            currentRoom = exitDictionary[keyWord];
            GameManager.gm.LogStringWithReturn("You head off to the " + keyWord);
            GameManager.gm.DisplayRoomText();
        }
        else
            GameManager.gm.LogStringWithReturn("You cannot go to the " + keyWord);
    }

    public void ClearExits()
    {
        exitDictionary.Clear();                             // Erases the exits from the current room
    }
}
