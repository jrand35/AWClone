using UnityEngine;
using System.Collections;

public class UnitStatus : MonoBehaviour {
    public int Movement;
    public int Attack;
    public int Defense;
    public int Range;
    private bool canAttack;
    private string RedOrBlue;
	// Use this for initialization
	void Start () {
        canAttack = false;
	}
    
    void Awake()
    {
        if (gameObject.tag == "blue")
        {
            RedOrBlue = "blue";
        }
        if (gameObject.tag == "red")
        {
            RedOrBlue = "red";
        }
    }
	
    // Update is called once per frame
	void Update () 
    {
      
	}
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag != RedOrBlue)
        {
            canAttack = false;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != RedOrBlue)
        {
            canAttack = true;
        }
    }
    
}
