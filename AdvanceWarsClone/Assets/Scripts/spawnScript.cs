//**********************************************************************************
//* spawnScript class: Used for spawning units at certain times
//**********************************************************************************
using UnityEngine;
using System.Collections;


/// <summary>
/// this script spwans units when their respective hotkey is pressed.
/// </summary>
public class spawnScript : MonoBehaviour {


   public GameObject spawnpoint; ///< Public reference to spawn position
   public GameObject infantry; ///< Public reference to infantry prefab
   public GameObject mech; ///< Public reference to mech prefab
   public GameObject recon;///< Public reference to recon prefab




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.anyKeyDown)
        {
            spwanunit();
        }
	
	}
	/// <summary>
	/// spawning logic
	/// </summary>
    void spwanunit()
    {
        //Spawn an infantry unit when I key is pressed
        if(Input.GetKeyDown(KeyCode.I))
        {
            Instantiate(infantry, new Vector3(spawnpoint.transform.position.x, spawnpoint.transform.position.y, spawnpoint.transform.position.z), Quaternion.identity);
            return;
        }
        
        //Spawn a mech unit when M key is pressed
        else if (Input.GetKeyDown(KeyCode.M))
        {
            Instantiate(mech, new Vector3(spawnpoint.transform.position.x, spawnpoint.transform.position.y, spawnpoint.transform.position.z), Quaternion.identity);
            return;
        }

        //Spawn a recon unit when R key is pressed
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(recon, new Vector3(spawnpoint.transform.position.x, spawnpoint.transform.position.y, spawnpoint.transform.position.z), Quaternion.identity);
            return;
        }

    }

}
