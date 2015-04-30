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
    private string EnemyColor;
	public GameObject ParentGameObject;
	// Use this for initialization
	void Start () {
        canAttack = false;
        Enemies = new List<GameObject>();
	}
    
    void Awake()
    {
        if (ParentGameObject.gameObject.tag == "blue")
        {
            EnemyColor = "red";
        }
        if (ParentGameObject.gameObject.tag == "red")
        {
            EnemyColor = "blue";
        }
		
    }
	
    // Update is called once per frame
	void Update () 
    {
      
	}
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == EnemyColor)
        {
            Enemies.Remove(col.gameObject);
			canAttack = false;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == EnemyColor)
        {
            Enemies.Add(col.gameObject);
			canAttack = true;
        }
    }

	public void AttackHim(int TotalAttack){
		TotalAttack = (Health / 2) * Attack;
	}
    
}
