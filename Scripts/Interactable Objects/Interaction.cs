using UnityEngine;

[System.Serializable]
public class Interaction
{
    public InputAction inputAction;         // Action associated with the interaction

    [TextArea]
    public string textResponse;             // Text displayed when the action is performed

    public ActionResponse actionResponse;   // Action performed in response to the input
}