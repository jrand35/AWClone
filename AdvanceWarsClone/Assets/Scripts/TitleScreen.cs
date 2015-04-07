using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {

    public enum gameStates
    {
        titleScreen = 0,
        mainGame
    }

    public gameStates currentState;
    public gameStates prevState;

    void Awake()
    {
        currentState = gameStates.titleScreen;
        prevState = currentState;
    }

    void OnEnable()
    {

    }

    void OnDisable()
    {

    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeGameState(gameStates newState)
    {
        switch (newState)
        {
            case gameStates.titleScreen:
                prevState = currentState;
                currentState = gameStates.titleScreen;
                break;

            case gameStates.mainGame:
                prevState = currentState;
                currentState = gameStates.mainGame;
                break;
        }
    }
}
