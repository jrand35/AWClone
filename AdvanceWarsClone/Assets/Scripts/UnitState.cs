//**********************************************************************************
//* UnitState class: The Unit's state machine
//**********************************************************************************
//* Joshua Rand
//**********************************************************************************

using UnityEngine;
using System.Collections;

///<summary>
///The Unit's state machine, attached to all Unit GameObjects
///<remarks>
///Author: Joshua Rand
///</remarks>
///</summary>
public class UnitState : MonoBehaviour
{
    public delegate void unitStateHandler(unitStates newState, GameObject caller);///< Delegate function called (selectively) whenever the unit state machine changes state
    public static event unitStateHandler unitStateChangeEvent;///< Delegate event for unitStateHandler
    public LayerMask Unit;///< Determines what GameObjects are considered "Units", set to Unit layer
    private Animator anim;///< Private reference to GameObjects Animator
    private unitStates currentState = unitStates.idle;///< Tracks the current state of the unit state machine
    private unitStates previousState = unitStates.idle;///< Tracks the previous state of the unit state machine
    private UnitStatus unitStatus;///< Private reference to child GameObject RangeColliders UnitStatus script
    private bool isSelected;///< Determines if the unit is currently selected (in its selected state)

    /// <summary>
    /// All of the Unit's enumerated states
    /// </summary>
    public enum unitStates
    {
        idle = 0,
        inactive,
        dead,
        selected,
        moving,
        attacking
    }

    /// <summary>
    /// Used for assigning variables
    /// </summary>
    void Awake()
    {
        //Get UnitStatus reference
		unitStatus = this.GetComponentInChildren<UnitStatus>();
    }

    void Update()
    {
        //Get the position of the mouse
        Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos = new Vector2(mouseWorldPoint.x, mouseWorldPoint.y);

        //Left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            //If hovering over a unit
            if (Physics2D.OverlapPoint(mousePos, Unit))
            {
                //If clicking on this unit
                if (Physics2D.OverlapPoint(mousePos) == collider2D)
                    OnUnitStateChange(unitStates.selected, gameObject, true);
                //If clicking on a different unit
                //Set this unit's state to idle, but do not communicate with HUDListener
                else
                    OnUnitStateChange(unitStates.idle, gameObject, false);
            }
            //If not hovering over any unit
            else if (!Physics2D.OverlapPoint(mousePos, Unit))
            {
                OnUnitStateChange(unitStates.idle, gameObject, true);
            }
        }
    }

    /// <summary>
    /// Determines what unit does based on its current state
    /// </summary>
    void onStateCycle()
    {
        switch (currentState)
        {
            case unitStates.idle:
                break;

            case unitStates.inactive:
                break;

            case unitStates.dead:
                break;

            case unitStates.selected:
                break;

            case unitStates.moving:
                break;

            case unitStates.attacking:
                break;
        }
    }

    /// <summary>
    /// Change the current state of the unit, delegEvent indicates whether or not to call delegate unitStateChangeEvent event
    /// </summary>
    /// <param name="newState"></param>
    /// <param name="caller"></param>
    /// <param name="delegEvent"></param>
    void OnUnitStateChange(unitStates newState, GameObject caller, bool delegEvent)
    {

        if (delegEvent)
            unitStateChangeEvent(newState, caller);

        previousState = currentState;
        currentState = newState;
 

        //When the state is first changed
        switch (newState)
        {
            case unitStates.idle:
			    unitStatus.AmISelected(false);
				Debug.Log(gameObject.name + " false");
				
                break;

            case unitStates.inactive:
                break;

            case unitStates.dead:
                Destroy(caller.gameObject);
                break;

            case unitStates.selected:
				Debug.Log(gameObject.name + " True");
				unitStatus.AmISelected(true);
                break;

            case unitStates.moving:
                break;

            case unitStates.attacking:
                break;
        }
        onStateCycle();
    }

    
}