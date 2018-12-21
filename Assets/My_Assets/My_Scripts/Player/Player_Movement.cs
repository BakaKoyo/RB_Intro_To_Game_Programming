using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour {


    #region [ Non-Tweekable Variables ]

    /* Player Movement Status */
    private string _str_PlayerMoveStatus = "Idle";

    /* Keybinds */
    private KeyCode _Key_Forward = KeyCode.W;
    private KeyCode _Key_Backward = KeyCode.S;
    private KeyCode _Key_Left = KeyCode.A;
    private KeyCode _Key_Right = KeyCode.D;
    private KeyCode _Key_Jump = KeyCode.Space;
    private KeyCode _Key_Sneak = KeyCode.X;
    private KeyCode _Key_Crouch = KeyCode.LeftControl;
    private KeyCode _Key_Run = KeyCode.LeftShift;
    private KeyCode _Key_Flashlight = KeyCode.F;

    /* Player Jumping */
    [SerializeField]
    private Rigidbody _Player_Rigidbody;
    [SerializeField]
    private float _Player_Gravity;

    /* Player's Camera */
    private Transform _Player_Camera;
    private Camera _Cam;

    /* Player Flashlight */
    [SerializeField]
    private GameObject _Player_Cam_Light;
    private bool _Player_IsCamOn = false; 

    #endregion


    #region [ Tweekable Variables ]

    /* Player's Movement Variables */
    [SerializeField]
    private float _Player_WalkSpeed;
    [SerializeField]
    private float _Player_RunSpeed;
    [SerializeField]
    private float _Player_CrouchedSpeed;
    [SerializeField]
    private float _Player_RotateSpeed;

    #endregion



    // Use this for initialization
    void Start ()
    {

        /* 
        Check if there is an Rigidbody component
            if it !=null get the rigidbody 
            else show a debug error 
        */
        if (GetComponent<Rigidbody>() != null) _Player_Rigidbody = GetComponent<Rigidbody>();
        else Debug.LogError(" No Rigidbody found! ");

        /* 
        Check if theres a Camera child of the prefab  
            if it != null get Child Camera
            else show a debug error 
        */
        if (GetComponentInChildren<Camera>() != null) _Cam = GetComponentInChildren<Camera>();
        else Debug.LogError(" No Camera found as the child component of this prefab! ");

        /*
        Check if theres a assigned Camera on the variable "_Cam" 
            if it != to null assign "_Cam" to "_Player_Camera"
            else show a debug error
        */
        if (_Cam != null) _Player_Camera = _Cam.transform;
        else Debug.LogError(" Missing Camera to assign to Player Camera! ");

        /*
        Checks if theres a Flashlight Gameobject on the player
            if it != to null then do default settings on the Flashlight
            else Show a debug error
        */
        if (_Player_Cam_Light != null) _Player_Cam_Light.SetActive(_Player_IsCamOn);
        else Debug.LogError(" Missing Flashlight Gameobject! ");


        /* Locks the Cursor on the center of the screen */
        Cursor.lockState = CursorLockMode.Locked;

  
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

                if  (Input.GetKey(_Key_Sneak)) _str_PlayerMoveStatus = "Sneakning";

                break;

            #endregion



            #region [ Moving ]

            case ("Moving"):

                /* Forwards and Backwards */
                if (Input.GetKey(_Key_Forward))
                {
                    transform.Translate(Vector3.forward * _Player_WalkSpeed * Time.deltaTime, Space.Self);
                }
                if (Input.GetKey(_Key_Backward))
                {
                    transform.Translate(Vector3.back * _Player_WalkSpeed / 2.0f * Time.deltaTime, Space.Self);
                }

                /* Left and Right */
                if (Input.GetKey(_Key_Left))
                {
                    transform.Rotate(Vector3.down * _Player_RotateSpeed * Time.deltaTime, Space.World);
                }
                if (Input.GetKey(_Key_Right))
                {
                    transform.Rotate(Vector3.up * _Player_RotateSpeed * Time.deltaTime, Space.World);
                }


                /* Other Player Movement */
                if (Input.GetKey(_Key_Sneak)) _str_PlayerMoveStatus = "Sneakning";


                /* Return to idle if the player has not touch a key */
                _str_PlayerMoveStatus = "Idle";

                break;

            #endregion



            #region [ Crouching & Sneakning ]

            case ("Sneakning"):

                /* Forwards and Backwards */
                if (Input.GetKey(_Key_Forward) && Input.GetKey(_Key_Sneak))
                {
                    transform.Translate(Vector3.forward * _Player_CrouchedSpeed * Time.deltaTime, Space.Self);
                }

                if (Input.GetKey(_Key_Backward) && Input.GetKey(_Key_Sneak))
                {
                    transform.Translate(Vector3.back * _Player_CrouchedSpeed * Time.deltaTime, Space.Self);
                }

                /* Left and Right */
  
                if (Input.GetKey(_Key_Left) && Input.GetKey(_Key_Sneak))
                {
                    transform.Rotate(Vector3.down * _Player_RotateSpeed * Time.deltaTime, Space.World);
                }
                if (Input.GetKey(_Key_Right) && Input.GetKey(_Key_Sneak))
                {
                    transform.Rotate(Vector3.up * _Player_RotateSpeed * Time.deltaTime, Space.World);
                }

                /* Return to idle if the player has not touch a key */
                _str_PlayerMoveStatus = "Idle";

                break;


                #endregion


        }
        #endregion


        #region [ Player Action ]

        /* Jump & Running */
        if (Input.GetKeyDown(_Key_Jump))
        {
            _Player_Rigidbody.velocity = Vector3.up * _Player_Gravity;
        }

        if (Input.GetKey(_Key_Run) && Input.GetKey(_Key_Forward)) 
        {
            transform.Translate(Vector3.forward * _Player_RunSpeed * Time.deltaTime, Space.Self);
        }

        if (Input.GetKey(_Key_Run) && Input.GetKey(_Key_Backward))
        {
            transform.Translate(Vector3.back * _Player_RunSpeed * Time.deltaTime, Space.Self);
        }

        #endregion


        #region [ Camera ]

        /* Camera Controls
        Vector3 _Mouse = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        _Mouse.Normalize();
        _Player_Camera.Rotate(_Mouse.x, 0.0f, 0.0f, Space.Self);
        _Player_Camera.Rotate(0.0f, _Mouse.y * 5.0f, 0.0f, Space.World);
        */


        /* Camera Flashlight */
        if (Input.GetKeyDown(_Key_Flashlight))
        {
            /* Toggle Flashlight */
            _Player_IsCamOn = !_Player_IsCamOn;

            /* On or Off */
            if (_Player_IsCamOn) _Player_Cam_Light.SetActive(true);
            else _Player_Cam_Light.SetActive(false);

        }

        #endregion

    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Win_Tag")
        {
            SceneManager.LoadScene(2);
        }

    }

}
