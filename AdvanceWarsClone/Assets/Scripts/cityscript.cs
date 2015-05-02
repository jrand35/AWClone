using UnityEngine;
using System.Collections;

public class cityscript : MonoBehaviour {

    private GameObject unit;
    public bool occupied;
    public int cityHealth = 10;
    private string citytag;

    public GameObject city;
    public GameObject redcity;
    public GameObject bluecity;
    public int healAmount;


	// Use this for initialization
	void Start () {


	
	}
	
    void OnTriggerEnter2D(Collider2D call)
    {
        //Debug.Log("enter trigger");
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
        if (unit.tag != citytag)
        {
            this.cityHealth -= 5;
            if(cityHealth <= 0)
            {
                if(unit.tag == "red")
                {
					this.redcity.SetActive(true);
                    this.redcity.renderer.enabled = true;
                    this.city.renderer.enabled = false;
                    this.bluecity.renderer.enabled = false;
					this.bluecity.SetActive(false);
                }
                else
                {
					this.bluecity.SetActive(true);
                    this.bluecity.renderer.enabled = true;
                    this.city.renderer.enabled = false;
                    this.redcity.renderer.enabled = false;
					this.redcity.SetActive(false);
                }
                cityHealth = 10;
                citytag = unit.tag;
            }
        }
    }





}
