///<summary>
///The Unit's state machine, attached to all Unit GameObjects
///<remarks>
///Author: Joshua Rand
///</remarks>
///</summary>
using UnityEngine;
using System.Collections;

/// <summary>
/// Unit states. event handler
/// </summary>
public class UnitState : MonoBehaviour
{
    /// <summary>
    /// Delegate function called (selectively) whenever the unit state machine changes state
    /// </summary>
    /// <param name="newState"></param>
    /// <param name="caller"></param>
    public delegate void unitStateHandler(unitStates newState, GameObject caller);
    /// <summary>
    /// Delegate event for unitStateHandler
    /// </summary>
    public static event unitStateHandler unitStateChangeEvent;
    /// <summary>
    /// Determines what GameObjects are considered "Units", set to Unit layer
    /// </summary>
    public LayerMask Unit;
    /// <summary>
    /// Private reference to GameObject's Animator
    /// </summary>
    private Animator anim;
    /// <summary>
    /// Tracks the current state of the unit state machine
    /// </summary>
    private unitStates currentState = unitStates.idle;
    /// <summary>
    /// Tracks the previous state of the unit state machine
    /// </summary>
    private unitStates previousState = unitStates.idle;
    /// <summary>
    /// Private reference to child GameObject RangeCollider's UnitStatus script
    /// </summary>
	private UnitStatus unitStatus;
    /// <summary>
    /// Determines if the unit is currently selected (in it's selected state)
    /// </summary>
	private bool isSelected;

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

    void Awake()
    {
		unitStatus = this.GetComponentInChildren<UnitStatus>();
    }

    void OnEnable()
    {
        
    }

    void OnDisable()
    {
        
    }

    void Update()
    {
        Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos = new Vector2(mouseWorldPoint.x, mouseWorldPoint.y);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics2D.OverlapPoint(mousePos, Unit))
            {
                bool deleg;
                if (Physics2D.OverlapPoint(mousePos) == collider2D)
                    OnUnitStateChange(unitStates.selected, gameObject, true);
                else
                    OnUnitStateChange(unitStates.idle, gameObject, false);
            }
            else if (!Physics2D.OverlapPoint(mousePos, Unit))
            {
                OnUnitStateChange(unitStates.idle, gameObject, true);
            }
        }
    }

    void LateUpdate()
    {
        onStateCycle();
    }

    void OnMouseEnter()
    {
        
        
    }

    void OnMouseExit()
    {
        
    }

    /// <summary>
    /// Called in LateUpdate(), determines what unit does based on its current state
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
        //Does return if newState == currentState
        //if (caller != gameObject)
        //    return;

        if (delegEvent)
            unitStateChangeEvent(newState, caller);

        //TODO: Check that a valid state transition is requested
        // if not return;

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
                //anim.SetBool("Inactive", true);
                break;

            case unitStates.dead:
                Destroy(caller.gameObject);    //May change
                break;

            case unitStates.selected:
				Debug.Log(gameObject.name + " True");
				unitStatus.AmISelected(true);
                break;

            case unitStates.moving:
                //anim.SetBool("Moving", true);
                break;

            case unitStates.attacking:
                //anim.SetBool("Attacking", true);
                break;
        }
    }

    
}