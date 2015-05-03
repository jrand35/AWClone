///<summary>
///The Game State Listener
///Defines the game states, determines when to change to the main game screen
///<remarks>
///Author: Joshua Rand
///</remarks>
///</summary>
using UnityEngine;
using System.Collections;

/// <summary>
/// Menu state controller.
/// </summary>
public class MenuStateController : MonoBehaviour {

    /// <summary>
    /// Game states
    /// </summary>
    public enum menuStates
    {
        titleScreen = 0,
        mapSelect
    }

    /// <summary>
    /// Delegate function handler for when the game changes state
    /// </summary>
    /// <param name="newState"></param>
    public delegate void MenuStateHandler(MenuStateController.menuStates newState);
    /// <summary>
    /// Delegate event for when game changes state
    /// </summary>
    public static event MenuStateHandler onStateChange;

    /// <summary>
    /// Called by Select Map button from the title screen, starts the game
    /// </summary>
    public void goToMapSelect()
    {
        onStateChange(MenuStateController.menuStates.mapSelect);
    }

	void LateUpdate () {
	}
}
