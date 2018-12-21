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
    private bool bln_IsPlayerAlive;


    /* Timer for enemy to be able to attack */
    private float flp_Enemy_Timer = 0.0f;

    /* Target Position */
    private Vector3 TargetPosition;
    private Vector3 Direction = Vector3.zero;

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
        Attack

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

        if (Target_Player != null)
        {
            TargetPosition = Target_Player.position - transform.position;
            TargetPosition.Normalize();
            Direction = TargetPosition;
        }

        if (bln_IsPlayerAlive)
        {
            switch (enemy_State)
            {
                case Enemy_State.Inactive:

                    enemy_State = Enemy_State.Idle;

                    break;


                case Enemy_State.Idle:

                    if (Vector3.Distance(Target_Player.position, transform.position) 
                        > Enemy_Detection_Range)
                        enemy_State = Enemy_State.Chase;

                    break;

                case Enemy_State.Chase:

                    if (Vector3.Distance(Target_Player.position, transform.position)
                        > Enemy_Detection_Range)
                        MoveEnemies();
                    else if (Vector3.Distance(Target_Player.position, transform.position)
                        < Enemy_Attack_Range)
                        enemy_State = Enemy_State.Attack;
                    else enemy_State = Enemy_State.Idle;

                        break;

                case Enemy_State.Attack:

                    if (Vector3.Distance(Target_Player.position, transform.position)
                        < Enemy_Attack_Range)
                        Attack_Player();
                    else enemy_State = Enemy_State.Idle;

                    break;

                default:
                    break;
            }
        }
        

    }

    private void MoveEnemies()
    {
        Direction.Normalize();
        transform.Translate(Direction * flp_EnemyMoveSpeed * Time.deltaTime);
    }
    
    private void Attack_Player()
    {

    }

}
