using UnityEngine;
using System.Collections;

public class UnitState : MonoBehaviour
{
    public delegate void unitStateHandler(unitStates newState, GameObject caller);
    public static event unitStateHandler unitStateChangeEvent;
    private Animator anim;
    private unitStates currentState = unitStates.idle;
    private unitStates previousState = unitStates.idle;

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

    }

    void OnEnable()
    {
        //UnitStateController.unitStateChangeEvent += OnUnitStateChange;
    }

    void OnDisable()
    {
        //UnitStateController.unitStateChangeEvent -= OnUnitStateChange;
    }

    void LateUpdate()
    {
        onStateCycle();
    }

    void OnMouseEnter()
    {
        OnUnitStateChange(unitStates.selected, gameObject);
    }

    void OnMouseExit()
    {
        OnUnitStateChange(unitStates.idle, gameObject);
    }

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

    void OnUnitStateChange(unitStates newState, GameObject caller)
    {
        if (newState == currentState || caller != gameObject)
            return;

        unitStateChangeEvent(newState, caller);

        //TODO: Check that a valid state transition is requested
        // if not return;

        previousState = currentState;
        currentState = newState;
 

        //When the state is first changed
        switch (newState)
        {
            case unitStates.idle:
                //anim.SetBool("Idle", true);
                break;

            case unitStates.inactive:
                //anim.SetBool("Inactive", true);
                break;

            case unitStates.dead:
                Destroy(caller.gameObject);    //May change
                break;

            case unitStates.selected:
                //onStateChange(UnitStateController.unitStates.idle, gameObject);
                //anim.SetBool("Selected", true);
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