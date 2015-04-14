using UnityEngine;
using System.Collections;

public class UnitMovment : MonoBehaviour {


    public float movespeed;
   // private Transform unitTransform;


	// Use this for initialization
	void Start () {

       // unitTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {

      //  unitTransform = this.transform;

        if (Input.GetKeyDown (KeyCode.LeftArrow))
        {
            moveUnit();
        }//end while

	} //end update
    void moveUnit()
    {
        this.transform.position.x = movespeed;
        return;
    }


}

