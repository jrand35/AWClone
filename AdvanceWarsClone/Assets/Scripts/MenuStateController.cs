using UnityEngine;
using System.Collections;

public class MenuStateController : MonoBehaviour {

    public enum menuStates
    {
        titleScreen = 0,
        mapSelect
    }

    public delegate void MenuStateHandler(MenuStateController.menuStates newState);
    public static event MenuStateHandler onStateChange;

    public void goToMapSelect()
    {
        onStateChange(MenuStateController.menuStates.mapSelect);
    }

    //Possibly use for changing states
	void LateUpdate () {
	}
}
