using UnityEngine;
using System.Collections;

public class MenuStateListener : MonoBehaviour {

    private MenuStateController.menuStates currentState = MenuStateController.menuStates.titleScreen;
    private MenuStateController.menuStates previousState = MenuStateController.menuStates.titleScreen;
    public GameObject titleScreenObject;
    public GameObject mapSelectObject;
    private bool titleScreenActive;
    private bool mapSelectActive;
    private Vector3 activePos;
    private Vector3 inactivePos;

    void Awake()
    {
        titleScreenActive = false;
        mapSelectActive = false;
        activePos = new Vector3(0f, 0f, 0f);
        inactivePos = new Vector3(0f, 0f, 0f);
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