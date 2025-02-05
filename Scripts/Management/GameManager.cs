using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private List<string> actionLog = new List<string>();            // List of all player inputs and responses

    [HideInInspector]
    public List<string> objectDescriptions = new List<string>();    // List of all object descriptions in the current room      

    [HideInInspector]
    public RoomNavigation roomNavigation;                           // 'RoomNavigation' script              

    [HideInInspector]
    public RoomObject roomObjects;                                  // 'RoomObject' script
    
    public static GameManager gm;                                   // Static reference to this 'GameManager' script
    public TMP_Text displayText;                                    // Textbox displaying all output
    public InputAction [] inputActions;                             // Array of all valid inputs

    public bool talkedToAmyOrLeonard = false;                       // Flag that checks if the player has talked to either Amy or Leonard
    public bool givenPenOrPaper = false;                            // Flag that checks if the player has given away either the pen or paper
    public bool givenSandwichOrMilk = false;                        // Flag that checks if the player has given away either the sandwich or milk
    public bool takenPen = false;                                   // Flag that checks if the player has picked up the pen
    public bool takenPaper = false;                                 // Flag that checks if the player has picked up the paper
    public bool takenCup = false;                                   // Flag that checks if the player has picked up the cup

    public int elevatorCount = 0;                                   // Counter that tracks elevator use

    private void Awake() 
    {
        // Set 'gm,' 'roomNavigation,' and 'roomObjects' to the scripts attached to this game object
        gm = this.gameObject.GetComponent<GameManager>();
        roomNavigation = this.gameObject.GetComponent<RoomNavigation>();
        roomObjects = this.gameObject.GetComponent<RoomObject>();
    }

    private void Start()
    {
        DisplayRoomText();                                          // Display the information for the current room
        DisplayLoggedText();                                        // Display all previous output
    }

    private void Update()
    {
        // Checks if the player is on the victory screen
        if (roomNavigation.currentRoom.roomName != "victory")
            return;

        // Quit the game if the player presses the 'Esc' key
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
    }

    // Gets the info for all exits and items in a room
    private void UnpackRoom()
    {
        roomNavigation.UnpackExitsInRoom();                         // Collects every exit in the room
        PrepareObjectsToInteract(roomNavigation.currentRoom);       // Collects every interactable item in the room
    }

    // Gets the descriptions for all interactable objects in the room
    private void PrepareObjectsToInteract(Room currentRoom)
    {
        // Loop through every item in the current room
        for (int i = 0; i < currentRoom.roomObjects.Length; i++)
        {
            string roomObjectDescription = roomObjects.GetObjectsNotInInventory(currentRoom, i);

            // Adds the item's description to 'objectDescriptions' if it hasn't been taken
            if (roomObjectDescription != null) objectDescriptions.Add(roomObjectDescription);
            else continue;

            InteractableObject roomObject = currentRoom.roomObjects[i];

            // Loops through every interaction for the current room object
            for (int j = 0; j < roomObject.interactions.Length; j++)
            {
                Interaction interaction = roomObject.interactions[j];
                
                // Checks the interaction's keyword and adds its text response to the corresponding dictionary
                if (interaction.inputAction.keyWord == "examine")
                    roomObjects.examineTexts.Add(roomObject.noun, interaction.textResponse);

                if (interaction.inputAction.keyWord == "take")
                    roomObjects.takeTexts.Add(roomObject.noun, interaction.textResponse);

                if (interaction.inputAction.keyWord == "talk")
                    roomObjects.talkTexts.Add(roomObject.noun, interaction.textResponse);
            }
        }
    }

    // Erases the information for the current room when moving
    private void ClearCollectionsForNewRoom()
    {
        roomObjects.ClearCollections();                         // Erases all of the current room's objects
        objectDescriptions.Clear();                             // Erases all of the room's objects' descriptions
        roomNavigation.ClearExits();                            // Erases all of the room's exits' information
    }

    // Tests to see if a given action can be performed on a given noun
    public string TestVerbDictionaryWithNoun(Dictionary<string, string> verbDictionary, string verb, string noun)
    {
        // Checks if the action has a response for the given noun and returns it
        if (verbDictionary.ContainsKey(noun))
            return verbDictionary[noun];

        // Returns message if the action does not have a response
        return "You can't " + verb + " " + noun;
    }

    // Displays the descriptions, exits, and items in a room
    public void DisplayRoomText()
    {
        ClearCollectionsForNewRoom();                               // Erases previous room info
        UnpackRoom();                                               // Collects info for current room

        // Joins room info to the room's description
        string interactionDescriptions = string.Join("\n", objectDescriptions.ToArray());
        string combinedText = roomNavigation.currentRoom.roomDescription + "\n" + interactionDescriptions;

        // Outputs all of the room's information
        LogStringWithReturn(combinedText);
    }

    // Adds a string to 'actionLog'
    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");
    }

    // Displays all text in 'actionLog'
    public void DisplayLoggedText()
    {
        string logAsText = string.Join("\n", actionLog.ToArray());
        displayText.text = logAsText;
    }
}