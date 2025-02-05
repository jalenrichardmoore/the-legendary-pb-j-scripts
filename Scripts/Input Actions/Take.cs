using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Text Adventure/Input Actions/Take")]
public class Take : InputAction
{
    public override void RespondToInput(string[] separatedInputWords)
    {
        // Attempts to take the object and store that object's text response associated with its 'take' action
        Dictionary<string, string> takeDictionary = GameManager.gm.roomObjects.Take(separatedInputWords);

        // Checks if the item was successfully taken and outputs its text response
        if (takeDictionary != null)
        {
            // If the item being taken was the pen, paper, or cup, change the flag to show that it has been permanently taken
            if (separatedInputWords[1] == "pen") GameManager.gm.takenPen = true;
            else if (separatedInputWords[1] == "paper") GameManager.gm.takenPaper = true;
            else if (separatedInputWords[1] == "cup") GameManager.gm.takenCup = true;

            GameManager.gm.LogStringWithReturn(GameManager.gm.TestVerbDictionaryWithNoun(takeDictionary, separatedInputWords[0], separatedInputWords[1]));
        }       
    }
}