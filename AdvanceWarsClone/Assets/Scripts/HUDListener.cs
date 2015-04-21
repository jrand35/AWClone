using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class HUDListener : MonoBehaviour
{

    private Text unitText;

    void OnEnable()
    {
        UnitStateController.unitStateChangeEvent += OnUnitStateChange;
    }

    void OnDisable()
    {
        UnitStateController.unitStateChangeEvent -= OnUnitStateChange;
    }

    void OnUnitStateChange(UnitStateController.unitStates newState, GameObject obj)
    {
        if (obj != null)
        {
            UnitStatus unitStatus = obj.GetComponent<UnitStatus>();
            unitText.text = "Movement: " + unitStatus.Movement + "\n" +
                "Attack: " + unitStatus.Attack + "\n" +
                "Defense: " + unitStatus.Defense + "\n" +
                "Range: " + unitStatus.Range;
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
