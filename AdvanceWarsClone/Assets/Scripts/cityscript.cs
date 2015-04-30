using UnityEngine;
using System.Collections;

public class cityscript : MonoBehaviour {

    private GameObject unit;
    public bool occupied;
    public int cityHealth = 10;

    public SpriteRenderer city;
    public SpriteRenderer redcity;
    public SpriteRenderer bluecity;
    public int healAmount;


	// Use this for initialization
	void Start () {


	
	}
	
    void OnTriggerEnter2D(Collider2D call)
    {
        Debug.Log("enter trigger");
        unit = call.gameObject;
        occupied = true;
    }

    void OnTriggerExit2D(Collider2D call)
    {
        unit = null;
        occupied = false;
        cityHealth = 10;
    }

	// Update is called once per frame
	void Update () {

        if (occupied == true)
        {
            if (unit.tag == gameObject.tag)
                heal();

            else if (occupied == true)
                capture();
        }

        
	
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
        if(unit.tag != this.tag)
        {
            this.cityHealth -= 5;
            if(cityHealth <= 0)
            {
                if(unit.tag == "red")
                {
                    this.redcity.enabled = true;
                    this.city.enabled = false;
                    this.bluecity.enabled = false;
                }
                else
                {
                    this.redcity.enabled = false;
                    this.city.enabled = false;
                    this.bluecity.enabled = true;
                }
                cityHealth = 10;
            }
        }
    }





}
