using UnityEngine;
using System.Collections;

public class UnitStatus : MonoBehaviour {
    public int Movement;
    public int Attack;
    public int Defense;
    public int Range;
    private bool canAttack;
	// Use this for initialization
	void Start () {
        canAttack = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
      
	}
    public void CanAttack(bool c)
    {
        canAttack = c;
    }
}
