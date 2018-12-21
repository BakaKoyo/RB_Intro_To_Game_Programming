using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Trigger_Collision : MonoBehaviour {

    
    public GameObject Enemy_Prefab;
    private GameObject NewGameObj = null;

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
        }
        else Debug.LogError(" No Enemy Prefab! ");

	}

    private void OnTriggerEnter(Collider other)
    {
        NewGameObj.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        NewGameObj.SetActive(false);
    }

}
