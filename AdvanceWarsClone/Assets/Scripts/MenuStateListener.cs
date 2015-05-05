//**********************************************************************************
//* MenuStateListener class: Controls what is displayed on title screen
//**********************************************************************************
//* 5/3/2015 JRaymond: Final version
//* 4/24/2015 JRand: Initial version
//**********************************************************************************

using UnityEngine;
using System.Collections;

///<summary>
///The Game State Listener.
///Listens for events from the menu state controller
///Defines what happens in each state of the game
///States are either on title screen or on the map
///<remarks>
///Author: Joshua Rand
///</remarks>
///</summary>
public class MenuStateListener : MonoBehaviour {

    private MenuStateController.menuStates currentState = MenuStateController.menuStates.titleScreen;///< The current state of the Game State Machine
    private MenuStateController.menuStates previousState = MenuStateController.menuStates.titleScreen;///< The previous state of the Game State Machine
    public GameObject titleScreenObject;///< Public reference to the title screen parent object. All children are objects that appear on the title screen
    public GameObject mapSelectObject;///< Public reference to the map select object. All children are objects that appear on the map select screen
    private bool titleScreenActive;///< Indicates if the title screen is currently active
    private bool mapSelectActive;///< Indicates if the map select screen is currently active

    /// <summary>
    /// Screen starts off inactive at the origin
    /// Screen is activated in titleScreen state
    /// Screen is inactive in mapSelect state
    /// </summary>
    void Awake()
    {
        titleScreenActive = false;
        mapSelectActive = false;
    }

    /// <summary>
    /// Listen for event onStateChange
    /// </summary>
    void OnEnable()
    {
        MenuStateController.onStateChange += onStateChange;
    }

    /// <summary>
    /// Detach from event onStateChange
    /// </summary>
    void OnDisable()
    {
        MenuStateController.onStateChange -= onStateChange;
    }

    /// <summary>
    /// Stub for Checking the state machine. Called in LateUpdate to make sure user input is processed.
    /// </summary>
    void LateUpdate()
    {
    }

    /// <summary>
    /// Check the state machine
    /// </summary>
    void onStateCycle()
    {
        switch (currentState)
        {
            // Turn title screen on, disable map selection
            case MenuStateController.menuStates.titleScreen:
                if (!titleScreenActive)
                {
                    titleScreenActive = true;
                    mapSelectActive = false;
                    titleScreenObject.SetActive(true);
                    mapSelectObject.SetActive(false);
                }
                break;

            // Turn title screen off, enable map selection
            case MenuStateController.menuStates.mapSelect:
                if (!mapSelectActive)
                {
                    titleScreenActive = false;
                    mapSelectActive = true;
                    titleScreenObject.SetActive(false);
                    mapSelectObject.SetActive(true);
                }
                break;
        }
    }

    /// <summary>
    /// Changes the current state of the game state machine
    /// Called by MenuStateController.onStateChange when the start button is clicked
    /// </summary>
    /// <param name="newState"></param>
    void onStateChange(MenuStateController.menuStates newState)
    {
        if (newState == currentState)
            return;
        switch (newState)
        {
            case MenuStateController.menuStates.titleScreen:
                break;

            case MenuStateController.menuStates.mapSelect:
                break;
        }
        onStateCycle();
        previousState = currentState;
        currentState = newState;
    }
}