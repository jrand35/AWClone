﻿//**********************************************************************************
//* UnitMovement class: The Unit's movement
//**********************************************************************************
using UnityEngine;
using System.Collections;

/// <summary>
/// Unit movment script.
/// </summary>
public class UnitMovment : MonoBehaviour {


    private float movespeed = 1.0f; ///< Speed at which units can move
    public float movedistance;///< Distance at which units are moving


	// Use this for initialization
	void Start () {

	}

    /// <summary>
    /// The Update method allows the player to move until it is out of moves.
    /// </summary>
	void Update () {

        
					
			if (movedistance > 0) {
            
				if (Input.GetKeyDown (KeyCode.RightArrow)) 
				{
                	moveX (movespeed);
   				}
            
				if (Input.GetKeyDown (KeyCode.LeftArrow)) 
				{
                	moveX (movespeed * -1);
            	}
            
				if (Input.GetKeyDown (KeyCode.UpArrow)) 
				{
					moveY (movespeed);
				}
            
				if (Input.GetKeyDown (KeyCode.DownArrow)) 
				{
					moveY (movespeed * -1);
				}
        

		}

	} //end update

	/// <summary>
	/// Moves the unit in the x direction.
	/// </summary>
	/// <param name="speed">Speed.</param>
    void moveX(float speed)
    {
        this.transform.position += new Vector3(speed,0,0);
        movedistance--;
        return;
    }
	/// <summary>
	/// Moves the unit in the y direction.
	/// </summary>
	/// <param name="speed">Speed.</param>
    void moveY(float speed)
    {
        this.transform.position += new Vector3(0, speed, 0);
        movedistance--;
        return;
    }


}

