using UnityEngine;

[CreateAssetMenu (menuName = "Text Adventure/Action Responses/Start Fight")]
public class StartFight : ActionResponse
{
    public Room roomToChangeTo;                             // Room to change to after the action is

    public override bool DoActionResponse()
    {
        if (!GameManager.gm.talkedToAmyOrLeonard)           // Checks if the player has talked to either Amy or Leonard
            GameManager.gm.talkedToAmyOrLeonard = true;     // Change flag to show that the player has talked to either of the two
        else
        {
            // Change the current room
            GameManager.gm.roomNavigation.currentRoom = roomToChangeTo;            
            GameManager.gm.DisplayRoomText();               // Display the information for the new room
        }
        return true;
    }
}