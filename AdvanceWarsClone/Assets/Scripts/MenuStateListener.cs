///<summary>
///The Game State Listener.
///Defines what happens in each state of the game
///States are either on title screen or on the map
///<remarks>
///Author: Joshua Rand
///</remarks>
///</summary>
using UnityEngine;
using System.Collections;


/// <summary>
/// Menu state listener. listens for events from the menu state controller
/// </summary>
public class MenuStateListener : MonoBehaviour {

    /// <summary>
    /// The current state of the Game State Machine
    /// </summary>
    private MenuStateController.menuStates currentState = MenuStateController.menuStates.titleScreen;
    /// <summary>
    /// The previous state of the Game State Machine
    /// </summary>
    private MenuStateController.menuStates previousState = MenuStateController.menuStates.titleScreen;
    /// <summary>
    /// Public reference to the title screen parent object. All children are objects that appear on the title screen
    /// </summary>
    public GameObject titleScreenObject;
    /// <summary>
    /// Public reference to the map select object. All children are objects that appear on the map select screen
    /// </summary>
    public GameObject mapSelectObject;
    /// <summary>
    /// Indicates if the title screen is currently active
    /// </summary>
    private bool titleScreenActive;
    /// <summary>
    /// Indicates if the map select screen is currently active
    /// </summary>
    private bool mapSelectActive;

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