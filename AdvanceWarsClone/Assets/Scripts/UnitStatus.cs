//**********************************************************************************
//* UnitStatus class: Stores the stats of each unit
//**********************************************************************************
//* Ben Melanson: Main Code
//* Josh Raymond: Movement Code
//**********************************************************************************

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// This Script is made to handle lots of events, like attacking and moving. All of the players stats are here,
/// as well as refrences to the colliders that detect whether or not there is an enemy in range.
/// <remarks>
/// Authors: 
///     Main Code: Ben Melanson
///     Movement Code: Josh Raymond
/// </remarks>
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
    /// <summary>
    /// Upon instanciation, the script checks to see what team it belongs to and sets the enemy color.
    /// This method also sets the unit state that is attached to the player.
    /// </summary>
    void Awake()
    {
        //If the unit is on the blue team, the enemy team is red
        if (ParentGameObject.gameObject.tag == "blue")
        {
            EnemyColor = "red";
        }

        //If the unit is on the red team, the enemy team is blue
        if (ParentGameObject.gameObject.tag == "red")
        {
            EnemyColor = "blue";
        }
		unitState = ParentGameObject.GetComponent<UnitState>();
		
    }
	
    /// <summary>
    /// The Update method checks to see if our player is selected, then allows the player to move until it is out of moves.
    /// </summary>
	void Update () 
    {
		if (selected) {
			
            //Move in a direction
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
    /// <summary>
    /// controls movement in the X direction
    /// </summary>
    /// <param name="speed"></param>
	void moveX(float speed)
	{
		ParentGameObject.transform.position += new Vector3(speed,0,0);
		Movement--;
		return;
	}
    /// <summary>
    /// controls movement in the Y direction
    /// </summary>
    /// <param name="speed"></param>
	void moveY(float speed)
	{
		ParentGameObject.transform.position += new Vector3(0, speed, 0);
		Movement--;
		return;
	}
    /// <summary>
    /// Checks to see if any enemies are leaving the range collider. If they are, those enemies are removed from the list of possible attackable enemies.
    /// </summary>
    /// <param name="col"></param>
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
    /// <summary>
    /// Checks to see if any enemies are entering the range collider. If they are, those enemies are added to the list of possible attackable enemies.
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == EnemyColor)
        {
            Enemies.Add(col.gameObject.GetComponentInChildren<UnitStatus>());
            Debug.Log(Enemies.Count);
			FireButton.SetActive(true);
        }
    }
    /// <summary>
    /// This method calculates how much damage it will apply to the enemy and checks the range collider for enemies. if it finds any, it attacks the first one in the list. 
    /// This is called by the FireButton object
    /// </summary>
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
    /// <summary>
    /// This is called by the AttackHim method. This takes the damage passed in by AttackHim and subtracts the units defense from it. Then it applies the remainder to the health.
    /// </summary>
    /// <param name="TotalAttack"></param>
    public void Attacked(int TotalAttack)
    {
        Health = Health - (TotalAttack - Defense);
		if (Health <= 0) {
			Destroy(ParentGameObject);
		}
    }
    /// <summary>
    /// This is called by the UnitState script and theoretically is supposed to set only the selected unit to true. However we never got the code working right.
    /// </summary>
    /// <param name="yorn"></param>
	public void AmISelected(bool yorn)
	{
		selected = yorn;
	}

}
