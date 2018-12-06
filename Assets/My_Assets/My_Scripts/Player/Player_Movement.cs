using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    #region [ Private ]

    /* Player Animation */
    private Animator _Anim_Player;


    #region [ Player Animation ]

    /* Player Animation Enum */
    [SerializeField]
    private enum PlayerAnimation
    {

    }

    #endregion

    #endregion



    // Use this for initialization
    void Start ()
    {

        /* 
        Checks if theres an Animator component
            if it != null get the animator
            else show a debug error 
        */
        if (GetComponent<Animator>() != null) _Anim_Player = GetComponent<Animator>();
        else Debug.LogError(" No Animator Found ");


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
