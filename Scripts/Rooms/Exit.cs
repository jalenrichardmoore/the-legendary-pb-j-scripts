[System.Serializable]
public class Exit
{
    public string [] keyStrings;        // The list of strings that are associated with this exit
    public string exitDescription;      // The text description of the exit
    public Room valueRoom;              // The room the exit leads to
}