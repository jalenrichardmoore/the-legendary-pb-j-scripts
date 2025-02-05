using UnityEngine;

public abstract class ActionResponse : ScriptableObject
{
    public string requiredString;                   // The string required to perform the action

    public abstract bool DoActionResponse();        // The action to perform in response to the specific input
}