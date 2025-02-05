using UnityEngine;

[CreateAssetMenu (menuName = "Text Adventure/Action Responses/Fill Cup")]
public class FillCup : ActionResponse
{
    public override bool DoActionResponse()
    {
        Room currentRoom = GameManager.gm.roomNavigation.currentRoom;

        // Checks if the player is in either the kitchen or the bathroom
        if (currentRoom.roomName != "kitchen" && currentRoom.roomName != "bathroom")
            return false;

        // Checks if the player has the cup in their inventory
        if (!GameManager.gm.roomObjects.objectsInInventory.Contains(requiredString))
            return false;

        // Remove the cup from the player's inventory
        GameManager.gm.roomObjects.objectsInInventory.Remove(requiredString);

        // Add the glass of water to the player's inventory
        GameManager.gm.roomObjects.Take(new string [] {"action", "water"});
        GameManager.gm.LogStringWithReturn("You put the cup under the running faucet and fill it with water.");
        return true;
    }
}