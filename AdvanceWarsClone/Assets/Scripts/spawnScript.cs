using UnityEngine;
using System.Collections;


/// <summary>
/// this script spwans units when their respective hotkey is pressed.
/// </summary>
public class spawnScript : MonoBehaviour {


   public GameObject spawnpoint;
   public GameObject infantry;
   public GameObject mech;
   public GameObject recon;




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

        if(Input.GetKeyDown(KeyCode.I))
        {
            Instantiate(infantry, new Vector3(spawnpoint.transform.position.x, spawnpoint.transform.position.y, spawnpoint.transform.position.z), Quaternion.identity);
            return;
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            Instantiate(mech, new Vector3(spawnpoint.transform.position.x, spawnpoint.transform.position.y, spawnpoint.transform.position.z), Quaternion.identity);
            return;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(recon, new Vector3(spawnpoint.transform.position.x, spawnpoint.transform.position.y, spawnpoint.transform.position.z), Quaternion.identity);
            return;
        }

    }

}
