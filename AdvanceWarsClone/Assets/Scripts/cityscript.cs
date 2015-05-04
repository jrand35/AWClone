using UnityEngine;
using System.Collections;

/// <summary>
/// Cityscript. This script has the logic for the buildings to determin whether a city is: 
/// occupied
/// captured
/// or should be healing a unit.
/// </summary>
public class cityscript : MonoBehaviour {

    private GameObject unit;///< Private reference to colliding unit
    public bool occupied;///< Determines if a city is currently occupied by units
    public int cityHealth = 10;///< When this is set to 0, the city is captured by a team
    private string citytag;///< Defines which team has captured the city

    public GameObject city;///< Public reference to city GameObject
    public GameObject redcity;///< Public reference to red city GameObject
    public GameObject bluecity;///< Public reference to blue city GameObject
    public int healAmount;///< The amount of health to restore units

	/// <summary>
	/// sets the unit occuping the city to the unit we occupied with
	/// </summary>
	/// <param name="call"></param>
    void OnTriggerEnter2D(Collider2D call)
    {
        //Debug.Log("enter trigger");
        unit = call.gameObject;
        occupied = true;
    }
    /// <summary>
    /// when the unit leaves the city we flush the variables
    /// </summary>
    /// <param name="call"></param>
    void OnTriggerExit2D(Collider2D call)
    {
        unit = null;
        occupied = false;
        cityHealth = 10;
    }

    /// <summary>
    /// checks to see if occupied is true and starts to heal the unit occuping the city
    /// </summary>
	void Update () {

        if (occupied == true)
        {
            if (unit.tag == gameObject.tag)
                heal();

            else if (occupied == true)
                capture();
        }

        
	
	}

	/// <summary>
	/// this function heals a unit that sits on a city for 2 health every turn
	/// </summary>
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

	/// <summary>
	/// this is the capture function meant to allow units to capture buildings. 
	/// </summary>
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
