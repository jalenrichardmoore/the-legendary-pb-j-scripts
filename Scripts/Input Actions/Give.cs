using UnityEngine;

[CreateAssetMenu (menuName = "Text Adventure/Input Actions/Give")]
public class Give : InputAction
{
    public override void RespondToInput(string[] separatedInputWords)
    {
        // Check if the item can be successfully given
        GameManager.gm.roomObjects.GiveItem(separatedInputWords);
    }
}