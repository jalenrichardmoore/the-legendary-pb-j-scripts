using UnityEngine;

[CreateAssetMenu (menuName = "Text Adventure/Input Actions/Use")]
public class Use : InputAction
{
    public override void RespondToInput(string[] separatedInputWords)
    {
        // Check if the item can be successfully used
        GameManager.gm.roomObjects.UseItem(separatedInputWords);
    }
}