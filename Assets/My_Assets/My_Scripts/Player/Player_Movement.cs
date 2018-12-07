using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {


    #region [ Public Variables ] 

    #endregion



    #region [ Private Variables ]


    #region [ Non-Tweekable Variables ]

    /* Player Animation */
    private Animator _Anim_Player;

    #endregion


    #region [ Tweekable Variables ]

    private float Player_WalkSpeed = 5.0f;
    

    #endregion

    #region [ Enums ]

    #region [ Player Animation ]

    /* Player Animation Enum */
    [SerializeField]
    private enum PlayerAnimation
    {
        Dying,
        Injured_Walk_3,
        Injured_Walk_2,
        Injured_Walk,
        Injured_Walk_Backwards,
        Backwards_Walk_Sneak,
        Backwards_Walk,
        Normal_Idle,
        Normal_Idle_Looking,
        Sitting_Idle,
        Normal_Walk,
        Normal_Walk_Left_Strafe,
        Normal_Walk_Right_Strafe,
        Crouched_Walk,
        Sneak_Walk,
        Sneak_Walk_Strafe,
        Crouched_Walk_Sneak,
        Walk_Stop,
    }




    #endregion

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
	void Update ()
    {
		
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Player_WalkSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Player_WalkSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * -Player_WalkSpeed, Space.World);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * Player_WalkSpeed, Space.World);
        }

    }
}
