using UnityEngine;

[CreateAssetMenu (menuName = "Text Adventure/Action Responses/Use Elevator")]
public class UseElevator : ActionResponse
{
    public Room goingUp;                        // Room to change to if the elevator is going up
    public Room goingDown;                      // Room to change to if the elevator is going down

    public override bool DoActionResponse()
    {
        // Checks if the player is in the elevator
        if (GameManager.gm.roomNavigation.currentRoom.roomName != requiredString) return false;

        // Checks if the player has the full elevator code
        if (!GameManager.gm.roomObjects.useActions.ContainsKey("8539")) return false;

        // Check if the elevator is going up or down
        if (GameManager.gm.elevatorCount % 2 == 0)
            GameManager.gm.roomNavigation.currentRoom = goingUp;
        else
            GameManager.gm.roomNavigation.currentRoom = goingDown;

        GameManager.gm.LogStringWithReturn("As you input the code, the elevator doors slam shut and you begin to move.");
        GameManager.gm.elevatorCount++;         // Increases the count of elevator uses
        GameManager.gm.DisplayRoomText();       // Displays the information for the new room
        return true;
    }
}