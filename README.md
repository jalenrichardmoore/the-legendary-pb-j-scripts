# **The Legendary PB&J - Scripts**

## **Overview**
This repository contains all necessary scripts for the Unity game, *The Legendary PB&J*. *The Legendary PB&J* is a text-based adventure game where the player must navigate a mansion, looking through rooms, collecting items, and interacting with people to make a sandwich. These scripts create scriptable objects to represent all room instances, text input, and events.

## **Folder Structure**
```plaintext
/Scripts/
|-- Action Responses/
│   ├── ActionResponse.cs                 # Defines the properties of an action response
│   ├── AddElevatorCode.cs                # Event to add elevator code to inventory
│   ├── FillCup.cs                        # Event to add water to cup in inventory
│   ├── MakeSandwich.cs                   # Event to make the sandwich
│   ├── StartFight.cs                     # Event to change room state in foyer
│   ├── TradeIngredient.cs                # Event to trade item for sandwich ingredient
│   ├── UseElevator.cs                    # Event to use elevator to move between floors
│   ├── WinGame.cs                        # Event to give sandwich away, winning the game
│   ├── WriteLoveLetter.cs                # Event to exchange paper for love letter
|-- Input Actions/
│   ├── Examine.cs                        # Action to examine all people and items in a room
│   ├── Give.cs                           # Action to remove an item from inventory
│   ├── Go.cs                             # Action to move between rooms
│   ├── InputAction.cs                    # Defines the properties of a valid input
│   ├── Inventory.cs                      # Action to display all items in inventory
│   ├── Take.cs                           # Action to remove item from room and place it in inventory
│   ├── Talk.cs                           # Action to talk to a person in a room
│   ├── Use.cs                            # Action to use an item in inventory to perform an action response
|-- Interactable Objects/
│   ├── InteractableObject.cs             # Defines the properties of an interactable object
│   ├── Interaction.cs                    # Defines the properties for the interactions that objects can have
|-- Management/
│   ├── GameManager.cs                    # Manages game state, current room, and tracks flags
│   ├── TextInput.cs                      # Handles the validation of player input
|-- Rooms/
│   ├── Exit.cs                           # Defines the properties of room exits
│   ├── Room.cs                           # Defines the properties of rooms
│   ├── RoomNavigation.cs                 # Handles movement between rooms
│   ├── RoomObject.cs                     # Determines all objects that can be interacted with in a room
└── README.md
```

## **Dependencies**
Unity Version: 6000.0.3

## **Installation & Usage**
1. Clone the repository:
```sh
git clone https://github.com/Jalen-Moore/the-legendary-pb-j-scripts.git
```

2. Copy the scripts into your Unity project's 'Assets/Scripts/' folder
   
## **Credits**
Developed by Jalen Moore
