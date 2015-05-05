//**********************************************************************************
//* MenuStateController class: The Game's State Machine
//**********************************************************************************
//* Joshua Rand
//**********************************************************************************

using UnityEngine;
using System.Collections;

///<summary>
///The Game State Controller
///Defines the game states, determines when to change to the main game screen
///<remarks>
///Author: Joshua Rand
///</remarks>
///</summary>
public class MenuStateController : MonoBehaviour {

    /// <summary>
    /// Game states
    /// </summary>
    public enum menuStates
    {
        titleScreen = 0,
        mapSelect
    }

    public delegate void MenuStateHandler(MenuStateController.menuStates newState);///<  Delegate function handler for when the game changes state
    public static event MenuStateHandler onStateChange;///< Delegate event for when game changes state

    /// <summary>
    /// Called by Select Map button from the title screen, starts the game
    /// </summary>
    public void goToMapSelect()
    {
        onStateChange(MenuStateController.menuStates.mapSelect);
    }
}
