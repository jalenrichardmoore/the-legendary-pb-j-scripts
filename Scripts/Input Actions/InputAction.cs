using UnityEngine;

public abstract class InputAction : ScriptableObject
{
    public string keyWord;          // The keyword associated with the action

    // The response the action performs
    public abstract void RespondToInput(string [] separatedInputWords);
}