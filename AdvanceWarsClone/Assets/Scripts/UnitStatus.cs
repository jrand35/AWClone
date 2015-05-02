using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitStatus : MonoBehaviour {
    public int Movement;
    public int Attack;
    public int Defense;
	public int Health;
	public int Range;
	private float movespeed = 1.0f;
	private List<UnitStatus> Enemies;
    private bool canAttack;
	private bool selected;
    private string EnemyColor;
	public GameObject ParentGameObject;
	private UnitState unitState;
	private GameObject[] EnemyArray;
	public GameObject FireButton;
	// Use this for initialization
	void Start () {
        canAttack = false;
        Enemies = new List<UnitStatus>();
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
		unitState = ParentGameObject.GetComponent<UnitState>();
		
    }
	
    // Update is called once per frame
	void Update () 
    {
		if (selected) {
			
			if (Movement > 0) {
				
				if (Input.GetKeyDown (KeyCode.RightArrow)) {
					moveX (movespeed);
				}
				
				if (Input.GetKeyDown (KeyCode.LeftArrow)) {
					moveX (movespeed * -1);
				}
				
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
					moveY (movespeed);
				}
				
				if (Input.GetKeyDown (KeyCode.DownArrow)) {
					moveY (movespeed * -1);
				}
				
			}
		}
	}
	void moveX(float speed)
	{
		ParentGameObject.transform.position += new Vector3(speed,0,0);
		Movement--;
		return;
	}
	void moveY(float speed)
	{
		ParentGameObject.transform.position += new Vector3(0, speed, 0);
		Movement--;
		return;
	}
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == EnemyColor) {
			Enemies.Remove (col.gameObject.GetComponentInChildren<UnitStatus>());
			Debug.Log (Enemies.Count);
			if (Enemies.Count <= 0)
			{
				canAttack = false;
				FireButton.SetActive(false);
			}
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == EnemyColor)
        {
            Enemies.Add(col.gameObject.GetComponentInChildren<UnitStatus>());
            Debug.Log(Enemies.Count);
			canAttack = true;
			FireButton.SetActive(true);
        }
    }

	public void AttackHim(){
		int TotalAttack = Mathf.RoundToInt ((Health / 2) * Attack);
		foreach (UnitStatus obj in Enemies) {
			obj.Attacked(TotalAttack);
			Enemies.Remove (obj);
			Debug.Log (Enemies.Count);
			if (Enemies.Count <= 0)
			{
				canAttack = false;
				FireButton.SetActive(false);
			}
		}

	}
    public void Attacked(int TotalAttack)
    {
        Health = Health - (TotalAttack - Defense);
		if (Health <= 0) {
			Destroy(ParentGameObject);
		}
    }
	public void AmISelected(bool yorn)
	{
		selected = yorn;
	}

}
