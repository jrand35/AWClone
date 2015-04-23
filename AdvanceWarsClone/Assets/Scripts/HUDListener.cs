using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class HUDListener : MonoBehaviour
{
    public Image HUDImage;
    public Text movementText;
    public Text attackText;
    public Text defenseText;
    public Text rangeText;

    void Start()
    {

    }

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
        switch (newState)
        {
            case UnitState.unitStates.selected:
                if (obj != null)
                {
                    UnitStatus unitStatus = obj.GetComponent<UnitStatus>();
                    movementText.text = "Movement: " + unitStatus.Movement;
                    attackText.text = "Attack: " + unitStatus.Attack;
                    defenseText.text = "Defense: " + unitStatus.Defense;
                    rangeText.text = "Range: " + unitStatus.Range;
                    HUDImage.enabled = true;
                }
                break;

            case UnitState.unitStates.idle:
                movementText.text = "";
                attackText.text = "";
                defenseText.text = "";
                rangeText.text = "";
                HUDImage.enabled = false;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
