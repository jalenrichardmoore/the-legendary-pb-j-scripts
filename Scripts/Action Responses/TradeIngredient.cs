using UnityEngine;

[CreateAssetMenu (menuName = "Text Adventure/Action Responses/Trade Ingredient")]
public class TradeIngredient : ActionResponse
{
    // List of items needed to trade for a sandwich ingredient
    public string [] itemsNeeded;

    public override bool DoActionResponse()
    {
        // Checks if the player is in the correct room
        if (GameManager.gm.roomNavigation.currentRoom.roomName != requiredString) 
            return false;

        // Loops through every needed item and checks if the player has it in their inventory
        for (int i = 0; i < itemsNeeded.Length; i++)
        {
            if (!GameManager.gm.roomObjects.objectsInInventory.Contains(itemsNeeded[i])) 
                return false;
        }

        // Remove all of the items being traded
        for (int i = 0; i < itemsNeeded.Length; i++)
            GameManager.gm.roomObjects.objectsInInventory.Remove(itemsNeeded[i]);

        // Checks which room the trade is occurring, and adds the appropriate items
        switch (requiredString)
        {
            case "den":
                GameManager.gm.roomObjects.Take(new string [] {"action", "peanut butter"});
                GameManager.gm.LogStringWithReturn("\"Thank you for the glass of water. I've been parched for days. Anyway, here is the peanut butter I promised. Enjoy!\"");
                break;
            case "kitchen":
                GameManager.gm.roomObjects.Take(new string [] {"action", "8539"});
                GameManager.gm.roomObjects.Take(new string [] {"action", "jelly"});
                GameManager.gm.LogStringWithReturn("\"Wow, I can't believe you actually managed to get this. Well, a deal's a deal. Enjoy the jelly.\"");
                break;
            case "office":
                GameManager.gm.roomObjects.Take(new string [] {"action", "milk"});
                break;
            case "foyer":
                GameManager.gm.roomObjects.Take(new string [] {"action", "bread"});
                GameManager.gm.LogStringWithReturn("Amy stops fighting with Leonard to read the letter. Her gaze stuck on the piece of paper, her eyes swell with tears. As the bread slices she had been hoarding fall out of her pockets, you sneakily steal two. Leonard throws a surprise attack, resuming their scuffle.");
                break;
        }
        return true;
    }
}