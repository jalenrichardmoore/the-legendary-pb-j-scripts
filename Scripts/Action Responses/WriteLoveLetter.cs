using UnityEngine;

[CreateAssetMenu (menuName = "Text Adventure/Action Responses/Write Love Letter")]
public class WriteLoveLetter : ActionResponse
{
    public string itemGiven;                                // The item being given

    public override bool DoActionResponse()
    {
        // Checks if the player is in the office
        if (GameManager.gm.roomNavigation.currentRoom.roomName != requiredString) return false;

        // Remove the object being given from the player's inventory
        GameManager.gm.roomObjects.objectsInInventory.Remove(itemGiven);

        if (!GameManager.gm.givenPenOrPaper)                // Checks if the player has given the mayor either the pen or paper
            GameManager.gm.givenPenOrPaper = true;          // Change flag to show the player has given either
        else
            // Add the love letter to the player's inventory
            GameManager.gm.roomObjects.Take(new string [] {"action", "letter"});

        return true;
    }
}