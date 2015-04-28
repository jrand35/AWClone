﻿using UnityEngine;
using System.Collections;

public class UnitRange : MonoBehaviour {
    public GameObject attachedUnit;
    private string RedOrBlue;
    public UnitStatus unitScript;
	// Use this for initialization
	void Start () 
    {
        if (attachedUnit.tag == "blue")
        {
            RedOrBlue = "blue";
        }
        if (attachedUnit.tag == "red")
        {
            RedOrBlue = "red";
        }
	}
    void OnTriggerExit2D(Collision2D col)
    {
        if (col.gameObject.tag != RedOrBlue)
        {
            unitScript.CanAttack(false);
        }
    }
    void OnTriggerEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != RedOrBlue)
        {
            unitScript.CanAttack(true);
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}