using UnityEngine;

[CreateAssetMenu (menuName = "Text Adventure/Action Responses/Win Game")]
public class WinGame : ActionResponse
{
    public Room victoryRoom;                            // Room representing the victory screen

    public override bool DoActionResponse()
    {
        // Checks if the player is in the basement
        if (GameManager.gm.roomNavigation.currentRoom.roomName != requiredString) return false;

        if (!GameManager.gm.givenSandwichOrMilk)        // Checks if the player has given the daughter either the sandwich or milk
            GameManager.gm.givenSandwichOrMilk = true;  // Change flag to show that the player has given either
        else
        {
            // Change the current room
            GameManager.gm.roomNavigation.currentRoom = victoryRoom;
            GameManager.gm.DisplayRoomText();           // Display the victory screen
        }
        return true;
    }
}