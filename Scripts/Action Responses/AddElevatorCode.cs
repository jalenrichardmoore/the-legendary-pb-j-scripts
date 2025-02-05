using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Text Adventure/Action Responses/Add Elevator Code")]
public class AddElevatorCode : ActionResponse
{
    public override bool DoActionResponse()
    {
        // Returns a list of all current items in the player's inventory
        List<string> inventory = GameManager.gm.roomObjects.objectsInInventory;

        // If the player already has the elevator code, return
        if (inventory.Contains("8539"))
            return true;

        // Checks if the player is talking to Sarah in the hallway
        if (GameManager.gm.roomNavigation.currentRoom.roomName == "hallway")
        {
            // Checks if the player already has the first half of the code
            if (inventory.Contains("85--"))
            {
                // Remove the first half and add the entire code to the inventory
                GameManager.gm.roomObjects.objectsInInventory.Remove("85--");
                GameManager.gm.roomObjects.Take(new string [] {"action", "8539"});
            }
            else
            {
                // Add the second half of the code to the player's inventory
                GameManager.gm.roomObjects.Take(new string [] {"action", "--39"});
            }
        }
        // Checks if the player is talking to Alan in the bedroom
        else if (GameManager.gm.roomNavigation.currentRoom.roomName == "bedroom")
        {
            // Checks if the player already has the second half of the code
            if (inventory.Contains("--39"))
            {
                // Remove the second half and add the entire code to the inventory
                GameManager.gm.roomObjects.objectsInInventory.Remove("--39");
                GameManager.gm.roomObjects.Take(new string [] {"action", "8539"});
            }
            else
            {
                // Add the first half of the code to the player's inventory
                GameManager.gm.roomObjects.Take(new string [] {"action", "85--"});
            }
        }
        return true;
    }
}