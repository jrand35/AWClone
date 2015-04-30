using UnityEngine;
using System.Collections;

public class cityscript : MonoBehaviour {

    private GameObject unit;
    private bool occupied;

    public GameObject city;
    public int healAmount;


	// Use this for initialization
	void Start () {


	
	}
	
    void OnTriggerEnter2D(Collider2D call)
    {
        unit = call.gameObject;
        occupied = true;
    }

    void OnTriggerExit2D(Collider2D call)
    {
        unit = null;
        occupied = false;
    }

	// Update is called once per frame
	void Update () {

        

        if (unit.tag == this.tag && occupied == true)
            heal();

        else if (occupied == true)
            capture();
	
	}

    private void heal()
    {
        if (unit.GetComponent<UnitStatus>().Health <= 10)
        {
            if (unit.GetComponent<UnitStatus>().Health == 10)
                unit.GetComponent<UnitStatus>().Health++;
            else
                unit.GetComponent<UnitStatus>().Health += 2;
        }
    }

    private void capture()
    {



    }





}
