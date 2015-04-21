using UnityEngine;
using System.Collections;

public class UnitStatus : MonoBehaviour {
    public int Movement;
    public int Attack;
    public int Defense;
    public int Range;
    public GameObject[] EnemyUnit;
    private float maxRange;
    private bool ClickedOn = false;
    private Ray rayToMouse;///< the ray to the mouse
	// Use this for initialization
	void Start () {
        maxRange = Range * Range;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (ClickedOn)
        {
            Targeting();
        }
        Vector3 newposition = transform.position;
        newposition.x = gameObject.transform.position.x;
        newposition.x = Mathf.Clamp(newposition.x, Range, Range * -1);
        transform.position = newposition;
	}
    void OnMouseDown()
    {
        ClickedOn = true;
    }
    void Targeting()
    {
        Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 catapultToMouse = mouseWorldPoint - gameObject.transform.position;

        if (catapultToMouse.sqrMagnitude > maxRange)
        {
            rayToMouse.direction = catapultToMouse;
            mouseWorldPoint = rayToMouse.GetPoint(Range);
        }

        mouseWorldPoint.z = 0f;
        transform.position = mouseWorldPoint;
    }



}
