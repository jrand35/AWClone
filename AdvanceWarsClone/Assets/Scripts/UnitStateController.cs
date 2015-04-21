using UnityEngine;
using System.Collections;

public class UnitStateController : MonoBehaviour
{

    public enum unitStates
    {
        idle = 0,
        inactive,
        dead,
        selected,
        moving,
        attacking
    }

    public delegate void UnitStateEvent(UnitStateController.unitStates newState, GameObject caller);
    public static event UnitStateEvent unitStateChangeEvent;

    void Update()
    {

    }

    //Possibly use for changing states
    void LateUpdate()
    {
    }
}
