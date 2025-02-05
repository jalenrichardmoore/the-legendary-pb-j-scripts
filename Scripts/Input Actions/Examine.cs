using UnityEngine;

[CreateAssetMenu (menuName = "Text Adventure/Input Actions/Examine")]
public class Examine : InputAction
{
    public override void RespondToInput(string[] separatedInputWords)
    {
        // Outputs the item's text description associated with the "examine" input action
        GameManager.gm.LogStringWithReturn(GameManager.gm.TestVerbDictionaryWithNoun(GameManager.gm.roomObjects.examineTexts, separatedInputWords[0], separatedInputWords[1]));
    }
}