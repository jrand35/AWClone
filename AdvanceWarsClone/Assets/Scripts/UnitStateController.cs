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

    public delegate void UnitSateHandler(UnitStateController.unitStates newState, GameObject caller);
    public static event UnitSateHandler onStateChange;

    void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        onStateChange(UnitStateController.unitStates.selected, gameObject);
    }

    //Possibly use for changing states
    void LateUpdate()
    {
    }
}
