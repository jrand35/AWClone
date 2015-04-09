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

    void OnDisable()
    {

    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
	    //Change states
	}
}
