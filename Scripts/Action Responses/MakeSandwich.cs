using UnityEngine;

[CreateAssetMenu (menuName = "Text Adventure/Action Responses/Make Sandwich")]
public class MakeSandwich : ActionResponse
{
    public override bool DoActionResponse()
    {
        // Checks if the player is in the kitchen
        if (GameManager.gm.roomNavigation.currentRoom.roomName != requiredString)
            return false;

        // Checks if the player has the peanut butter and jelly
        if (!GameManager.gm.roomObjects.objectsInInventory.Contains("peanut butter") || !GameManager.gm.roomObjects.objectsInInventory.Contains("jelly"))
            return false;

        // Removes the ingredients from the player's inventory and adds the sandwich
        GameManager.gm.roomObjects.objectsInInventory.Remove("bread");
        GameManager.gm.roomObjects.objectsInInventory.Remove("peanut butter");
        GameManager.gm.roomObjects.objectsInInventory.Remove("jelly");
        GameManager.gm.roomObjects.Take(new string [] {"action", "sandwich"});
        GameManager.gm.LogStringWithReturn("You take the peanut butter and jelly and slather them onto the bread slices, creating a PB&J. Truly legendary.");
        return true;
    }
}