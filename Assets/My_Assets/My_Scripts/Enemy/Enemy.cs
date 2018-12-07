using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {


    #region [ Variables ]


    #region [ Non-Tweakable Variables ] 

    /* Enemy Target is the player */
    public Transform Target_Player;

    /* Enemy Direction */
    protected Vector3 Enemy_Direction = Vector3.zero;

    /* Boolean for the Player if it's Alive or not */
    protected bool bln_IsPlayerAlive = true;


    /* Timer for enemy to be able to attack */
    protected float flp_Enemy_Timer = 0.0f;
    

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


    // Use this for initialization
    void Start ()
    {

        /* Checks if there is a specified Target found 
            if there is no target found, give out an error */
        if (Target_Player == null)
            Debug.LogError(" There is no Target found! Please add a Target");

    }
	
	// Update is called once per frame
	void Update ()
    {

        IsPlayerAlive();

	}


    /* Function that checks if the Player is alive
        If the player is alive call the this function 
            else call Player_Dead()*/
    protected virtual void IsPlayerAlive()
    {

        switch (bln_IsPlayerAlive)
        {


            case true:
                /* If the Player is Alive
                    check if target is within Enemy's Dectection Range
                        If it is call the function Move_Enemy()*/
                if (Vector3.Distance(Target_Player.position, transform.position) > Enemy_Detection_Range)
                    Move_Enemy();

                /* If Enemy is lower than the "Enemy_Detection_Range"
                    check if the target is within "Enemy_Attack_Range"
                        If it is call the function Enemy_Attack_Player();
                   else call Move_Enemy() */
                if (Vector3.Distance(Target_Player.position, transform.position) <= Enemy_Detection_Range)
                {
                    if (Vector3.Distance(Target_Player.position, transform.position) <= Enemy_Attack_Range)
                        Enemy_Attack_Player();
                    else Move_Enemy();
                }

                break;

        }

    }

    /* Function only gets called when the player is alive 
        If enemy is within "Attack Range" then call Enemy_Attack_Player()
            else either keep moving if the player is still within "Detection Range" */
    protected virtual void Move_Enemy()
    {

    }


    protected virtual void Enemy_Attack_Player()
    {

    }

}
