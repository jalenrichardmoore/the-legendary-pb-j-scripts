using UnityEngine;

[CreateAssetMenu (menuName = "Text Adventure/Input Actions/Go")]
public class Go : InputAction
{
    public override void RespondToInput(string[] separatedInputWords)
    {
        // Check to see if the player can move to the specified room
        GameManager.gm.roomNavigation.AttemptToChangeRoom(separatedInputWords[1]);
    }
}