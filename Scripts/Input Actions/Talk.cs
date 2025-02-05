using UnityEngine;

[CreateAssetMenu (menuName = "Text Adventure/Input Actions/Talk")]
public class Talk : InputAction
{
    public override void RespondToInput(string[] separatedInputWords)
    {
        // Get the room the player is currently in
        Room currentRoom = GameManager.gm.roomNavigation.currentRoom;

        // Display the text response for the person the player is talking to
        GameManager.gm.LogStringWithReturn(GameManager.gm.TestVerbDictionaryWithNoun(GameManager.gm.roomObjects.talkTexts, separatedInputWords[0], separatedInputWords[1]));

        // Loops through every object in the current room
        for (int i = 0; i < currentRoom.roomObjects.Length; i++)
        {
            // Checks if the person's 'talk' interaction has an action associated with it
            if (currentRoom.roomObjects[i].interactions[0].actionResponse == null)
                continue;

            // If the person's 'talk' interaction has an associated action, perform it
            if (currentRoom.roomObjects[i].noun == separatedInputWords[1])
            {
                currentRoom.roomObjects[i].interactions[0].actionResponse.DoActionResponse();
                break;
            }
        }
    }
}