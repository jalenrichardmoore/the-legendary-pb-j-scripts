using UnityEngine;
using TMPro;

public class TextInput : MonoBehaviour
{
    public TMP_InputField inputField;                           // Input field for the player

    private void Awake() 
    {
        inputField.onEndEdit.AddListener(AcceptStringInput);    // Calls 'AcceptStringInput' when input field accepts input
    }

    // Takes in user input and responds to to actions given
    void AcceptStringInput(string userInput)
    {
        userInput = userInput.ToLower();                        // Sets user input to lowercase
        GameManager.gm.LogStringWithReturn(userInput);          // Displays the user's input

        char [] delimiterCharacters = {' '};

        // Separates the words in the user's input into an array
        string [] separatedInputWords = userInput.Split(delimiterCharacters);

        // Loops through every possible input action
        for (int i = 0; i < GameManager.gm.inputActions.Length; i++)
        {
            InputAction inputAction = GameManager.gm.inputActions[i];

            // If the user input a specific input action, perform that action on their input
            if (inputAction.keyWord == separatedInputWords[0])
                inputAction.RespondToInput(separatedInputWords);
        }

        InputComplete();                                        // Prepare to receive more user input
    }

    // Prepares the input field to receive more user input
    void InputComplete() 
    {
        GameManager.gm.DisplayLoggedText();                     // Displays all of 'actionLog'
        inputField.ActivateInputField();                        // Reactivates the input field
        inputField.text = null;                                 // Empties the input field
    }
}