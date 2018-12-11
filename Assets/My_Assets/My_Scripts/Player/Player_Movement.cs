﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {


    #region [ Public Variables ] 

    public int Player_Lives = 3;

    #endregion



    #region [ Private Variables ]


    #region [ Non-Tweekable Variables ]

    /* Player Movement Status */
    private string _str_PlayerMoveStatus = "Idle";

    /* Keybinds */
    private KeyCode _Key_Forward = KeyCode.W;
    private KeyCode _Key_Backward = KeyCode.S;
    private KeyCode _Key_Left = KeyCode.A;
    private KeyCode _Key_Right = KeyCode.D;
    private KeyCode _Key_LookLeft = KeyCode.Q;
    private KeyCode _Key_LookRight = KeyCode.E;
    private KeyCode _Key_Jump = KeyCode.Space;
    private KeyCode _Key_Sneak = KeyCode.LeftShift;
    private KeyCode _Key_Crouch = KeyCode.LeftControl;

    /* Player Jumping */
    [SerializeField]
    private Rigidbody _Player_Rigidbody;
    [SerializeField]
    private float _Player_Gravity;

    #endregion


    #region [ Tweekable Variables ]

    /* Player's Movement Variables */
    [SerializeField]
    private float _Player_WalkSpeed;
    [SerializeField]
    private float _Player_CrouchedSpeed;
    [SerializeField]
    private float _Player_RotateSpeed;

    #endregion


    #endregion


    // Use this for initialization
    void Start ()
    {

        /* 
        Cehck if there is an Rigidbody component
            if it !=null get the rigidbody 
            else show a debug error 
        */
        if (GetComponent<Rigidbody>() != null) _Player_Rigidbody = GetComponent<Rigidbody>();
        else Debug.LogError(" No Rigidbody found ");

        _Player_Rigidbody = GetComponent<Rigidbody>();

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
                else _str_PlayerMoveStatus = "Idle";

                if (Input.GetKey(_Key_Crouch) || Input.GetKey(_Key_Sneak)) _str_PlayerMoveStatus = "Crouching & Sneakning";

                break;

            #endregion



            #region [ Moving ]

            case ("Moving"):

                /* Forwards and Backwards */
                if (Input.GetKey(_Key_Forward))
                {
                    transform.Translate(Vector3.forward * _Player_WalkSpeed * Time.deltaTime);
                }
                if (Input.GetKey(_Key_Backward))
                {
                    transform.Translate(Vector3.back * _Player_WalkSpeed / 2.0f * Time.deltaTime);
                }

                /* Left and Right */
                if (Input.GetKey(_Key_Left))
                {
                    transform.Rotate(Vector3.down * _Player_RotateSpeed * Time.deltaTime);
                }
                if (Input.GetKey(_Key_Right))
                {
                    transform.Rotate(Vector3.up * _Player_RotateSpeed * Time.deltaTime);
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
                if (Input.GetKey(_Key_Forward) && Input.GetKey(_Key_Crouch))
                {
                    transform.Translate(Vector3.forward * _Player_CrouchedSpeed * Time.deltaTime);
                }
                else if (Input.GetKey(_Key_Forward) && Input.GetKey(_Key_Sneak))
                {
                    transform.Translate(Vector3.forward * _Player_CrouchedSpeed * Time.deltaTime);
                }
                else if (Input.GetKey(_Key_Forward) && Input.GetKey(_Key_Crouch) && Input.GetKey(_Key_Sneak))
                {
                    transform.Translate(Vector3.forward * _Player_CrouchedSpeed * Time.deltaTime);
                }

                if (Input.GetKey(_Key_Backward) && Input.GetKey(_Key_Sneak))
                {
                    transform.Translate(Vector3.back * _Player_CrouchedSpeed / 2.0f * Time.deltaTime);
                }

                /* Left and Right */
                if (Input.GetKey(_Key_Left) && Input.GetKey(_Key_Sneak))
                {
                    transform.Rotate(Vector3.down * _Player_RotateSpeed * Time.deltaTime);
                }
                if (Input.GetKey(_Key_Right) && Input.GetKey(_Key_Sneak))
                {
                    transform.Rotate(Vector3.up * _Player_RotateSpeed * Time.deltaTime);
                }

                /* Return to idle if the player has not touch a key */
                _str_PlayerMoveStatus = "Idle";

                break;


                #endregion

        }
        #endregion

        if (Input.GetKey(KeyCode.Space))
        {
            _Player_Rigidbody.velocity = Vector3.up * _Player_Gravity;
        }
       

    }
}
