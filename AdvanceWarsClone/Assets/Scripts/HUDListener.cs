///<summary>
///Attached to the HUD GameObject, displays the stats of the currently selected unit
///<remarks>
///Author: Joshua Rand
///</remarks>
///</summary>
using UnityEngine.UI;
using UnityEngine;
using System.Collections;


/// <summary>
/// HUD listener. this script updates the HUD when a unit is selected
/// </summary>
public class HUDListener : MonoBehaviour
{
    /// <summary>
    /// Private reference to the child Text object
    /// Displays the currently selected unit's Movement, Attack, Defense and Health
    /// </summary>
    private Text unitText;

    void OnEnable()
    {
        UnitState.unitStateChangeEvent += OnUnitStateChange;
    }

    void OnDisable()
    {
        UnitState.unitStateChangeEvent -= OnUnitStateChange;
    }

    /// <summary>
    /// Called by UnitState.unitStateChangeEvent
    /// Displays the unit's stats when newState is set to selected and provided a reference to the unit GameObject
    /// Displays empty stats when newState is set to idle
    /// </summary>
    /// <param name="newState"></param>
    /// <param name="obj"></param>
    void OnUnitStateChange(UnitState.unitStates newState, GameObject obj)
    {
        if (newState == UnitState.unitStates.selected)
        {
            if (obj != null)
            {
                UnitStatus unitStatus = obj.GetComponentInChildren<UnitStatus>();
                unitText.text = "Movement: " + unitStatus.Movement + "\n" +
                    "Attack: " + unitStatus.Attack + "\n" +
                    "Defense: " + unitStatus.Defense + "\n" +
					"Health: " + unitStatus.Health;
            }
        }
        else if (newState == UnitState.unitStates.idle)
        {
            UnitStatus unitStatus = obj.GetComponent<UnitStatus>();
            unitText.text = "Movement: " + "\n" +
                "Attack: " + "\n" +
                "Defense: " + "\n" +
                "Health: ";
        }
    }

    // Use this for initialization
    void Start()
    {
        unitText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
