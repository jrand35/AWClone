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
	private bool selected;
    private string EnemyColor;
	public GameObject ParentGameObject;
	public GameObject FireButton;
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
		if (selected) {
			
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
		}
	}
	void moveX(float speed)
	{
		ParentGameObject.transform.position += new Vector3(speed,0,0);
		movedistance--;
		return;
	}
	void moveY(float speed)
	{
		ParentGameObject.transform.position += new Vector3(0, speed, 0);
		movedistance--;
		return;
	}
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == EnemyColor) {
			Enemies.Remove (col.gameObject);
			Debug.Log (Enemies.Count);
			if (Enemies.Count <= 0)
			{
				canAttack = false;
			}
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == EnemyColor)
        {
            Enemies.Add(col.gameObject);
            Debug.Log(Enemies.Count);
			canAttack = true;
        }
    }

	public void AttackHim(){
		int TotalAttack = Mathf.RoundToInt((Health / 2) * Attack);

		Enemy.Attacked (TotalAttack);
	}

    public void Attacked(int TotalAttack)
    {
        Health = Health - (TotalAttack - Defense);
		if (Health <= 0) {
			Destroy(ParentGameObject);
		}
    }
	public void isSelected(bool yorn)
	{	
		selected = yorn;
	}
}
