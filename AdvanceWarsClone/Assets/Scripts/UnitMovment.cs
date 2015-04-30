using UnityEngine;
using System.Collections;

public class UnitMovment : MonoBehaviour {


    private float movespeed = 1f;
    public float movedistance;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (movedistance > 0)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                moveX(movespeed);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                moveX(movespeed * -1);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                moveY(movespeed);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                moveY(movespeed * -1);
            }
        }


	} //end update
    void moveX(float speed)
    {
        this.transform.position += new Vector3(speed,0,0);
        movedistance--;
        return;
    }
    void moveY(float speed)
    {
        this.transform.position += new Vector3(0, speed, 0);
        movedistance--;
        return;
    }


}

