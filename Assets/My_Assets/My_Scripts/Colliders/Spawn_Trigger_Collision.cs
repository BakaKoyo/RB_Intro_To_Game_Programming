using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Trigger_Collision : MonoBehaviour {

    
    public GameObject Enemy_Prefab;
    private GameObject NewGameObj = null;

    private bool bln_IsInSpawnRange = false;

	// Use this for initialization
	void Start ()
    {

        /* Null Check if theres an Enemy prefab set on the script
              if it is then set the enemy prefab to the new game object
              else show debug error */
        if (Enemy_Prefab == null) Debug.LogError(" No set Enemy Prefab ");

        if (NewGameObj == null)
        {
            NewGameObj = Instantiate(Enemy_Prefab);

            NewGameObj.SetActive(false);
        }
        else Debug.LogError(" No Enemy Prefab! ");

        

	}
	
	// Update is called once per frame
	void Update ()
    {

        if (bln_IsInSpawnRange) NewGameObj.SetActive(true);
        else NewGameObj.SetActive(false);


    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player_Prefab_Tag")
        {
            bln_IsInSpawnRange = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player_Prefab_Tag")
        {
            bln_IsInSpawnRange = false;
        }

    }

}
