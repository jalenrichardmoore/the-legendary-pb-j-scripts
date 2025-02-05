using UnityEngine;

[CreateAssetMenu (menuName = "Text Adventure/Input Actions/Inventory")]
public class Inventory : InputAction
{
    public override void RespondToInput(string[] separatedInputWords)
    {
        // Displays all objects currently in the player's inventory
        GameManager.gm.roomObjects.DisplayInventory();
    }
}