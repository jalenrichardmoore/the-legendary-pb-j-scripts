using UnityEngine;

[CreateAssetMenu (menuName = "Text Adventure/Room")]
public class Room : ScriptableObject
{
    public string roomName;                     // Name associated with the room

    [TextArea]
    public string roomDescription;              // Description of the room
    public Exit [] roomExits;                   // Array of exits from the room
    public InteractableObject [] roomObjects;   // Array of interactable objects in the room
}