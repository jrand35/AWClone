using UnityEngine.UI;
using UnityEngine;
using System.Collections;

///<summary>
/// HUD listener. this script updates the HUD when a unit is selected
///<remarks>
///Author: Joshua Rand
///</remarks>
///</summary>
public class HUDListener : MonoBehaviour
{
    private Text unitText;///< Private reference to the child Text object, Displays the currently selected units Movement, Attack, Defense and Health

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
