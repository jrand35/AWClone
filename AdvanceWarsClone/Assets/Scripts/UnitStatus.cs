using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitStatus : MonoBehaviour {
    public int Movement;
    public int Attack;
    public int Defense;
	public int Health;
	public int Range;
	private List<GameObject> Enemies;
    private bool canAttack;
    private string RedOrBlue;
	public GameObject ParentGameObject;
	// Use this for initialization
	void Start () {
        canAttack = false;
	}
    
    void Awake()
    {
        if (ParentGameObject.gameObject.tag == "blue")
        {
            RedOrBlue = "blue";
        }
        if (ParentGameObject.gameObject.tag == "red")
        {
            RedOrBlue = "red";
        }
		Debug.Log (RedOrBlue);
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
			Enemies.Add(col.gameObject);
			Debug.Log(Enemies.Count);
			canAttack = true;
        }
    }

	public void AttackHim(int TotalAttack){
		TotalAttack = (Health / 2) * Attack;
	}
    
}
