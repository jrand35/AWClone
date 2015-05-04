///<summary>
///The Game State Listener.
///Listens for events from the menu state controller
///Defines what happens in each state of the game
///States are either on title screen or on the map
///<remarks>
///Author: Joshua Rand
///</remarks>
///</summary>
using UnityEngine;
using System.Collections;
public class MenuStateListener : MonoBehaviour {

    private MenuStateController.menuStates currentState = MenuStateController.menuStates.titleScreen;///< The current state of the Game State Machine
    private MenuStateController.menuStates previousState = MenuStateController.menuStates.titleScreen;///< The previous state of the Game State Machine
    public GameObject titleScreenObject;///< Public reference to the title screen parent object. All children are objects that appear on the title screen
    public GameObject mapSelectObject;///< Public reference to the map select object. All children are objects that appear on the map select screen
    private bool titleScreenActive;///< Indicates if the title screen is currently active
    private bool mapSelectActive;///< Indicates if the map select screen is currently active

    void Awake()
    {
        titleScreenActive = false;
        mapSelectActive = false;
    }

    void OnEnable()
    {
        MenuStateController.onStateChange += onStateChange;
    }

    void OnDisable()
    {
        MenuStateController.onStateChange -= onStateChange;
    }

    void LateUpdate()
    {
        onStateCycle();
    }

    /// <summary>
    /// Called in LateUpdate(), defines what happens in each state of the state machine
    /// </summary>
    void onStateCycle()
    {
        switch (currentState)
        {
            case MenuStateController.menuStates.titleScreen:
                if (!titleScreenActive)
                {
                    titleScreenActive = true;
                    mapSelectActive = false;
                    titleScreenObject.SetActive(true);
                    mapSelectObject.SetActive(false);
                }
                break;

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
        previousState = currentState;
        currentState = newState;
    }
}