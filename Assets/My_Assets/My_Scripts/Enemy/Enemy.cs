using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    #region [ Variables ]


    #region [ Non-Tweakable Variables ] 

    /* Enemy Target is the player */
    public Transform Target_Player;

    /* Enemy Direction */
    private Vector3 Enemy_Direction = Vector3.zero;

    /* Boolean for the Player if it's Alive or not */
    public bool bln_IsPlayerAlive;


    /* Timer for enemy to be able to attack */
    private float flp_Enemy_Timer = 0.0f;


    #endregion

    /*---------------------------------------------------------*/

    #region [ Tweakable Variables ]

    /* Enemy's Movespeed */
    protected float flp_EnemyMoveSpeed = 10.0f;

    /* Enemy's Dection Range */
    protected float Enemy_Detection_Range = 10.0f;

    /* Enemy's Attack Range */
    protected float Enemy_Attack_Range = 5.0f;

    /* Set float for the time it takes for enemy can attack */
    protected float flp_Enemy_TimeToAttack = 10.0f;

    #endregion


    #endregion


    #region [ Enum ]

    private enum Enemy_State
    {

        Inactive =-1,
        Idle,
        Chase,
        Patrol,
        Flee,
        Attack,
        Dead

    }

    #endregion



    [SerializeField]
    private Enemy_State enemy_State = Enemy_State.Inactive;


    // Use this for initialization
    void Start ()
    {

        /* Checks if there is a specified Target found 
            if there is no target found, give out an error */
        if (Target_Player == null)
            Debug.LogError(" There is no Target found! Please add a Target");
        else bln_IsPlayerAlive = true;

    }
	
    

	// Update is called once per frame
	void Update ()
    {

     

    }



}
