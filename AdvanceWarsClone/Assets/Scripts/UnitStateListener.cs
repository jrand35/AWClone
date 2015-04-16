using UnityEngine;
using System.Collections;

public class UnitStateListener : MonoBehaviour
{

    private Animator anim;
    private UnitStateController.unitStates currentState = UnitStateController.unitStates.idle;
    private UnitStateController.unitStates previousState = UnitStateController.unitStates.idle;

    void Awake()
    {

    }

    void OnEnable()
    {
        UnitStateController.unitStateChangeEvent += OnUnitStateChange;
    }

    void OnDisable()
    {
        UnitStateController.unitStateChangeEvent -= OnUnitStateChange;
    }

    void OnMouseDown()
    {
        OnUnitStateChange(UnitStateController.unitStates.selected, gameObject);
    }

    void LateUpdate()
    {
        onStateCycle();
    }

    void onStateCycle()
    {
        switch (currentState)
        {
            case UnitStateController.unitStates.idle:
                break;

            case UnitStateController.unitStates.inactive:
                break;

            case UnitStateController.unitStates.dead:
                break;

            case UnitStateController.unitStates.selected:
                break;

            case UnitStateController.unitStates.moving:
                break;

            case UnitStateController.unitStates.attacking:
                break;
        }
    }

    void OnUnitStateChange(UnitStateController.unitStates newState, GameObject caller)
    {
        Debug.Log(caller.ToString() + " is Entering OnUnitStateChange");
        if (newState == currentState)
            return;

        //TODO: Check that a valid state transition is requested
        // if not return;

        previousState = currentState;
 

        //When the state is first changed
        switch (newState)
        {
            case UnitStateController.unitStates.idle:
                //anim.SetBool("Idle", true);
                break;

            case UnitStateController.unitStates.inactive:
                //anim.SetBool("Inactive", true);
                break;

            case UnitStateController.unitStates.dead:
                Destroy(caller.gameObject);    //May change
                break;

            case UnitStateController.unitStates.selected:
                caller.transform.position = new Vector3(-1000f, -1000f, -1000f);
                //currentState = UnitStateController.unitStates.idle;

  
                //onStateChange(UnitStateController.unitStates.idle, gameObject);
                //anim.SetBool("Selected", true);
                break;

            case UnitStateController.unitStates.moving:
                //anim.SetBool("Moving", true);
                break;

            case UnitStateController.unitStates.attacking:
                //anim.SetBool("Attacking", true);
                break;
        }
    }
}