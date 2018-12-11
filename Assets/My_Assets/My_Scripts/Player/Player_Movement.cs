using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {


    #region [ Public Variables ] 

    #endregion



    #region [ Private Variables ]


    #region [ Non-Tweekable Variables ]

    /* Player Movement Status */
    private string _str_PlayerMoveStatus = "Idle";

    /* Player Animation */
    private Animator _Animator_Player;

    /* Afk Timer */
    private float _AFK_Timer = 10.0f;
    private float _AFK_HalfTimer = 5.0f;
    private float _AFK_Time = 0.0f;

    /* Player Blend Tree Animation */
    private float _Anim_Player_Dying = -7.0f;
    private float _Anim_Player_Injuired_Walk_3 = -6.0f;
    private float _Anim_Player_Injuired_Walk_2 = -5.0f;
    private float _Anim_Player_Injuired_Walk = -4.0f;
    private float _Anim_Player_Injuired_Walk_Backwards = -3.0f;
    private float _Anim_Player_Backwards_Walk_Sneak = -2.0f;
    private float _Anim_Player_Backwards_Walk = -1.0f;
    private float _Anim_Player_Normal_Idle = 0.0f;
    private float _Anim_Player_Normal_Idle_Looking = 1.0f;
    private float _Anim_Player_Sitting_Idle = 2.0f;
    private float _Anim_Player_Normal_Walk = 3.0f;
    private float _Anim_Player_Normal_Walk_Left = 4.0f;
    private float _Anim_Player_Normal_Walk_Right = 5.0f;
    private float _Anim_Player_Crouched_Walk = 6.0f;
    private float _Anim_Player_Sneak_Walk = 7.0f;
    private float _Anim_Player_Sneak_Walk_Strafe_Left = 8.0f;
    private float _Anim_Player_Sneak_Walk_Strafe_Right = 9.0f;
    private float _Anim_Player_Crouched_Walk_Sneak = 10.0f;
    private float _Anim_Player_Walk_Stop = 11.0f;

    /* Keybinds */
    private KeyCode _Key_Forward = KeyCode.W;
    private KeyCode _Key_Backward = KeyCode.S;
    private KeyCode _Key_Left = KeyCode.A;
    private KeyCode _Key_Right = KeyCode.D;
    private KeyCode _Key_Interact = KeyCode.E;
    private KeyCode _Key_Crouch = KeyCode.LeftControl;
    private KeyCode _Key_Run = KeyCode.LeftShift;

    #endregion


    #region [ Tweekable Variables ]

    /* Player's Movement Variables */
    [SerializeField]
    private float _Player_WalkSpeed;
    [SerializeField]
    private float _Player_RunSpeed;
    [SerializeField]
    private float _Player_RotateSpeed;

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
        if (GetComponent<Animator>() != null) _Animator_Player = GetComponent<Animator>();
        else Debug.LogError(" No Animator Found ");


	}
	
	// Update is called once per frame
	void Update ()
    {
		
        switch(_str_PlayerMoveStatus)
        {

            #region [ Idle ] 

            case ("Idle"):

                /* If player presses a button then switch the state to "Moving" */
                if (Input.GetKey(_Key_Forward) || Input.GetKey(_Key_Backward) || Input.GetKey(_Key_Left)
                        || Input.GetKey(_Key_Right) || Input.GetKey(_Key_Crouch) || Input.GetKey(_Key_Run))
                {
                    _str_PlayerMoveStatus = "Moving";
                }
                else _Animator_Player.SetFloat("Animation", _Anim_Player_Normal_Idle);

                break;

            case ("Moving"):

                /* Forwards and Backwards */
                if (Input.GetKey(_Key_Forward))
                {
                    transform.Translate(Vector3.forward * _Player_WalkSpeed * Time.deltaTime, Space.Self);
                    _Animator_Player.SetFloat("Animation", _Anim_Player_Normal_Walk);
                }
                if (Input.GetKey(_Key_Backward))
                {
                    transform.Translate(Vector3.back * _Player_WalkSpeed /2 * Time.deltaTime, Space.Self);
                    _Animator_Player.SetFloat("Animation", _Anim_Player_Backwards_Walk);
                }

                /* Left and Right */
                if (Input.GetKey(_Key_Left))
                {
                    transform.Rotate(Vector3.down * _Player_RotateSpeed * Time.deltaTime, Space.World);
                    _Animator_Player.SetFloat("Animation", _Anim_Player_Normal_Walk_Left);
                }
                if (Input.GetKey(_Key_Right))
                {
                    transform.Rotate(Vector3.up * _Player_RotateSpeed * Time.deltaTime, Space.World);
                    _Animator_Player.SetFloat("Animation", _Anim_Player_Normal_Walk_Right);
                }

                /* Return to idle if the player has not touch a key */
                _str_PlayerMoveStatus = "Idle";

                break;

            #endregion

        }


    }
}
