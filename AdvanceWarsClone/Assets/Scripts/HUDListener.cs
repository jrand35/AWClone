using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class HUDListener : MonoBehaviour
{

    private Text unitText;

    void OnEnable()
    {
        UnitState.unitStateChangeEvent += OnUnitStateChange;
    }

    void OnDisable()
    {
        UnitState.unitStateChangeEvent -= OnUnitStateChange;
    }

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
                    "Range: " + unitStatus.Range + "\n" +
					"Health: " + unitStatus.Health;
            }
        }
        else if (newState == UnitState.unitStates.idle)
        {
            UnitStatus unitStatus = obj.GetComponent<UnitStatus>();
            unitText.text = "Movement: " + "\n" +
                "Attack: " + "\n" +
                "Defense: " + "\n" +
                "Range: ";
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
