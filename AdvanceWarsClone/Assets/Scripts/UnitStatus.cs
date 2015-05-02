using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// This Script is made to handle lots of events, like attacking and moving. All of the players stats are here,
/// as well as refrences to the colliders that detect whether or not there is an enemy in range.
/// </summary>
public class UnitStatus : MonoBehaviour {
    public int Movement;///< How far we can move in one turn.
    public int Attack;///< our Attack Stat
	public int Defense;///< our Defense Stat
	public int Health;///< our Health Stat
	private float movespeed = 1.0f;///< Determines how far one move is
	private List<UnitStatus> Enemies;///< A List of enemies that is added to when an enemy collides with our trigger
	private bool selected;///< A bool that checks if we are selected. if we are, then we can move.
	private string EnemyColor;///< The enemy team color
	public GameObject ParentGameObject;///< the gameobject that this script is attached to
	private UnitState unitState;///< A refrence to the unit state script
	public GameObject FireButton;///< The Button on screen that says FIRE!
	/// <summary>
	/// Instantiates the list
	/// </summary>
	void Start () 
	{
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
