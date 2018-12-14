using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animations : MonoBehaviour {

    #region [ Private Variables ]

    #region [ Non-Tweekable Variables ]

    /* Player Movement Status */
    private string _str_PlayerMoveStatus = "Idle";

    /* Player Animation */
    private Animator _Animator_Player;

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
    private float _Anim_Player_Running_Backwards = 8.0f;
    private float _Anim_Player_Running_Forwards = 9.0f;
    private float _Anim_Player_Crouched_Walk_Sneak = 10.0f;
    private float _Anim_Player_Jump = 11.0f;

    /* Keybinds */
    private KeyCode _Key_Forward = KeyCode.W;
    private KeyCode _Key_Backward = KeyCode.S;
    private KeyCode _Key_Left = KeyCode.A;
    private KeyCode _Key_Right = KeyCode.D;
    private KeyCode _Key_LookLeft = KeyCode.Q;
    private KeyCode _Key_LookRight = KeyCode.E;
    private KeyCode _Key_Jump = KeyCode.Space;
    private KeyCode _Key_Run = KeyCode.LeftAlt;
    private KeyCode _Key_Sneak = KeyCode.LeftShift;
    private KeyCode _Key_Crouch = KeyCode.LeftControl;

    #endregion

    #region [ Tweekable Variables ]

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
        else Debug.LogError(" No Animator found! ");

    }
	
	// Update is called once per frame
	void Update ()
    {

        #region [ Player Movement ]

        switch (_str_PlayerMoveStatus)
        {

            #region [ Idle ] 

            case ("Idle"):

                /* If player presses a button then switch the state to "Moving" */
                if (Input.GetKey(_Key_Forward) || Input.GetKey(_Key_Backward) || Input.GetKey(_Key_Left)
                        || Input.GetKey(_Key_Right))
                {
                    _str_PlayerMoveStatus = "Moving";
                }
                else _Animator_Player.SetFloat("Animation", _Anim_Player_Normal_Idle);

                if (Input.GetKey(_Key_Crouch) || Input.GetKey(_Key_Sneak)) _str_PlayerMoveStatus = "Crouching & Sneakning";

                break;

            #endregion



            #region [ Moving ]

            case ("Moving"):

                /* Forwards and Backwards */
                if (Input.GetKey(_Key_Forward))
                {
                    _Animator_Player.SetFloat("Animation", _Anim_Player_Normal_Walk);
                }
                if (Input.GetKey(_Key_Backward))
                { 
                    _Animator_Player.SetFloat("Animation", _Anim_Player_Backwards_Walk);
                }

                /* Left and Right */
                if (Input.GetKey(_Key_Left))
                {
                    _Animator_Player.SetFloat("Animation", _Anim_Player_Normal_Walk_Left);
                }
                if (Input.GetKey(_Key_Right))
                {
                    _Animator_Player.SetFloat("Animation", _Anim_Player_Normal_Walk_Right);
                }


                /* Other Player Movement */
                if (Input.GetKey(_Key_Crouch) || (Input.GetKey(_Key_Sneak))) _str_PlayerMoveStatus = "Crouching & Sneakning";


                /* Return to idle if the player has not touch a key */
                _str_PlayerMoveStatus = "Idle";

                break;

            #endregion



            #region [ Crouching & Sneakning ]

            case ("Crouching & Sneakning"):

                /* Forwards and Backwards */

                if (Input.GetKey(_Key_Forward) && Input.GetKey(_Key_Sneak))
                {
                    _Animator_Player.SetFloat("Animation", _Anim_Player_Sneak_Walk);
                }
                if (Input.GetKey(_Key_Backward) && Input.GetKey(_Key_Sneak))
                {
                    _Animator_Player.SetFloat("Animation", _Anim_Player_Backwards_Walk_Sneak);
                }

 
                /* Return to idle if the player has not touch a key */
                _str_PlayerMoveStatus = "Idle";

                break;


                #endregion

        }

        #endregion

        #region [ Player Action ]

        if (Input.GetKey(_Key_Jump))
        {
            _Animator_Player.SetFloat("Animation", _Anim_Player_Jump);
        }

        if (Input.GetKey(_Key_Run) && Input.GetKey(_Key_Forward))
        {
            _Animator_Player.SetFloat("Animation", _Anim_Player_Running_Forwards);
        }

        if (Input.GetKey(_Key_Run) && Input.GetKey(_Key_Backward))
        {
            _Animator_Player.SetFloat("Animation", _Anim_Player_Running_Backwards);
        }

        #endregion

    }
}
