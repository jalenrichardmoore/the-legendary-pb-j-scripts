using System.Collections.Generic;
using UnityEngine;

public class RoomObject : MonoBehaviour
{
    [HideInInspector]
    public List<string> objectsInRoom = new List<string>();             // List of objects in the current room
    public List<string> objectsInInventory = new List<string>();        // List of objects in the player's inventory

    public List<InteractableObject> usableItemList;                     // List of all items that can be used
    public List<InteractableObject> giveableItemList;                   // List of all items that can be given

    // Dictionary of every text response when examining an item
    public Dictionary<string, string> examineTexts = new Dictionary<string, string>();

    // Dictionary of every text response when taking an item
    public Dictionary<string, string> takeTexts = new Dictionary<string, string>();

    // Dictionary of every text response when talking to a person
    public Dictionary<string, string> talkTexts = new Dictionary<string, string>();

    // Dictionary of every action response when using an item
    public Dictionary<string, ActionResponse> useActions = new Dictionary<string, ActionResponse>();
    
    // Dictionary of every action response when giving an item
    public Dictionary<string, ActionResponse> giveActions = new Dictionary<string, ActionResponse>();

    // Checks if an object can be used
    private InteractableObject GetObjectFromUsableList(string noun)
    {
        // Loops through every usable item possible
        for (int i = 0; i < usableItemList.Count; i++)
        {
            // Checks if the item trying to be used is in the list
            if (usableItemList[i].noun == noun) return usableItemList[i];
        }
        return null;
    }

    // Checks if an object can be given
    private InteractableObject GetObjectFromGiveableList(string noun)
    {
        // Loops through every giveable item possible
        for (int i = 0; i < giveableItemList.Count; i++)
        {
            // Checks if the item trying to be used is in the list
            if (giveableItemList[i].noun == noun) return giveableItemList[i];
        }
        return null;
    }

    // Gets the description of an room's object that hasn't been taken
    public string GetObjectsNotInInventory(Room currentRoom, int i)
    {
        // Get the current object
        InteractableObject roomObject = currentRoom.roomObjects[i];

        // If the object is the 'pen,' check if the player has already used the pen
        if (roomObject.noun == "pen" && GameManager.gm.takenPen) return null;
        
        // If the object is the 'paper,' check if the player has already used the paper
        if (roomObject.noun == "paper" && GameManager.gm.takenPaper) return null;

        // If the object is the 'cup,' check if the player has already used the cup
        if (roomObject.noun == "cup" && GameManager.gm.takenCup) return null;
    
        // Checks if the player already has the object in their inventory
        if (objectsInInventory.Contains(roomObject.noun)) return null;

        objectsInRoom.Add(roomObject.noun);                                 // Adds the object to the list of room objects
        return roomObject.description;
    }

    // Checks if an item can be used and adds its associated response to 'useActions'
    public void AddActionResponsesToUseDictionary() 
    {
        // Loops through every item in the player's inventory
        for (int i = 0; i < objectsInInventory.Count; i++)
        {
            // Get the current item
            string item = objectsInInventory[i];

            // Check if the item can be used
            InteractableObject itemInInventory = GetObjectFromUsableList(item);

            if (itemInInventory == null) continue;

            // Loop through every interaction associated with the item
            for (int j = 0; j < itemInInventory.interactions.Length; j++)
            {
                // Get the current interaction
                Interaction interaction = itemInInventory.interactions[j];

                // Checks if the interaction has an action response
                if (interaction.actionResponse == null) continue;

                // Adds the item and its associated response to 'useActions' if it hasn't been added
                if (!useActions.ContainsKey(item) && interaction.inputAction.keyWord == "use")
                    useActions.Add(item, interaction.actionResponse);
            }
        }
    }

    // Checks if an item can be given and adds its associated response to 'giveActions'
    public void AddActionResponsesToGiveDictionary() 
    {
        // Loops through every item in the player's inventory
        for (int i = 0; i < objectsInInventory.Count; i++)
        {
            // Get the current item
            string item = objectsInInventory[i];

            // Check if the item can be given
            InteractableObject itemInInventory = GetObjectFromGiveableList(item);

            if (itemInInventory == null) continue;

            // Loop through every interaction associated with the item
            for (int j = 0; j < itemInInventory.interactions.Length; j++)
            {
                // Get the current interaction
                Interaction interaction = itemInInventory.interactions[j];

                // Checks if the interaction has an action response
                if (interaction.actionResponse == null) continue;

                // Adds the item and its associated response to 'giveActions' if it hasn't been added
                if (!giveActions.ContainsKey(item) && interaction.inputAction.keyWord == "give")
                    giveActions.Add(item, interaction.actionResponse);
            }
        }
    }

    // Displays every item currently in the player's inventory    
    public void DisplayInventory()
    {
        GameManager.gm.LogStringWithReturn("You look at the items you have collected. You have: ");

        // Loops through every item in the player's inventory and adds it to 'actionLog'
        for (int i = 0; i < objectsInInventory.Count; i++)
            GameManager.gm.LogStringWithReturn(objectsInInventory[i]);
        
    }

    // Erases the text responses and items in the current room
    public void ClearCollections()
    {
        examineTexts.Clear();
        takeTexts.Clear();
        talkTexts.Clear();
        objectsInRoom.Clear();
    }

    // Removes an object from the current room and adds it to the player's inventory
    public Dictionary<string, string> Take(string [] separatedInputWords)
    {
        // Gets the item being taken
        string item = separatedInputWords[1];

        // Checks if the item being added is the result of an action
        if (separatedInputWords[0] == "action")
        {
            objectsInInventory.Add(item);                                       // Adds the item to the inventory
            AddActionResponsesToUseDictionary();                                // Adds the item's 'use' response
            AddActionResponsesToGiveDictionary();                               // Adds the item's 'give' response
            return takeTexts;
        }

        // Checks if the item is in the current room
        if (!objectsInRoom.Contains(item))
        {
            GameManager.gm.LogStringWithReturn("There is no " + item + " here to take.");
            return null;
        }

        objectsInInventory.Add(item);                                           // Adds the item to the inventory
        AddActionResponsesToUseDictionary();                                    // Adds the item's 'use' response
        AddActionResponsesToGiveDictionary();                                   // Adds the item's 'give' response
        objectsInRoom.Remove(item);                                             // Remove the item from the room
        return takeTexts;
    }

    // Checks if an item can be used and performs that item's 'use' response if possible
    public void UseItem(string [] separatedInputWords)
    {
        // Gets the item being used
        string itemToUse = separatedInputWords[1];

        // Checks if the item is in the player's inventory
        if (!objectsInInventory.Contains(itemToUse))
        {
            GameManager.gm.LogStringWithReturn("There is no " + itemToUse + " in your inventory.");
            return;
        }

        // Checks if the item can be used
        if (!useActions.ContainsKey(itemToUse))
        {
            GameManager.gm.LogStringWithReturn("You cannot use the " + itemToUse + ".");
            return;
        }

        // Try to use the item
        bool actionResult = useActions[itemToUse].DoActionResponse();

        // Checks if the action was successful
        if (!actionResult)
            GameManager.gm.LogStringWithReturn("You tried to use the " + itemToUse + ", but nothing happened");
    }

    // Checks if an item can be given and performs that item's 'give' response if possible
    public void GiveItem(string [] separatedInputWords)
    {
        // Gets the item being used
        string itemToGive = separatedInputWords[1];

        // Checks if the item is in the player's inventory
        if (!objectsInInventory.Contains(itemToGive))
        {
            GameManager.gm.LogStringWithReturn("There is no " + itemToGive + " in your inventory.");
            return;
        }

        // Checks if the item can be used
        if (!giveActions.ContainsKey(itemToGive))
        {
            GameManager.gm.LogStringWithReturn("You cannot give the " + itemToGive + ".");
            return;
        }

        // Try to use the item
        bool actionResult = giveActions[itemToGive].DoActionResponse();

        // Checks if the action was successful
        if (!actionResult)
            GameManager.gm.LogStringWithReturn("You tried to give the " + itemToGive + ", but nothing happened");
    }
}