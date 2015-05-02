using UnityEngine;
using System.Collections;

public class UnitState : MonoBehaviour
{
    public delegate void unitStateHandler(unitStates newState, GameObject caller);
    public static event unitStateHandler unitStateChangeEvent;
    private GameObject AttachedGameObject;
    public LayerMask Unit;
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
                Debug.Log(gameObject.name);
				AttachedGameObject.isSelected(false);
                break;

            case unitStates.inactive:
                //anim.SetBool("Inactive", true);
                break;

            case unitStates.dead:
                Destroy(caller.gameObject);    //May change
                break;

            case unitStates.selected:
				AttachedGameObject.isSelected(true);
                break;

            case unitStates.moving:
                //anim.SetBool("Moving", true);
                break;

            case unitStates.attacking:
                //anim.SetBool("Attacking", true);
                break;
        }
    }

    void Attack()
    {
        
    }
}