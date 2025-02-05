using UnityEngine;

[CreateAssetMenu (menuName = "Text Adventure/Interactable Object")]
public class InteractableObject : ScriptableObject
{
    public string noun;                     // The name associated with the object

    [TextArea]
    public string description;              // Description of the object

    public Interaction [] interactions;     // Array of all possible interactions with the object
}