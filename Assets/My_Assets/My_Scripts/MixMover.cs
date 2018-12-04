using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixMover : MonoBehaviour {


    private float runSpeed = .7f;
    private float walkSpeed = .3f;
    public float rotateSpeed = 60f;

    //    public Transform rotationNode;

    private Animator anim;

    private float speed;
    private float direction;

    #region [ My Added Variables ]

    [SerializeField]
    private float _WalkSpeed;

    [SerializeField]
    private float _RunSpeed;

    [SerializeField]
    private float _JumpSpeed;

    private float jumpSpeed = 1.0f;

    #endregion

    // Use this for initialization
    void Start ()
    {

        if (GetComponent<Animator>() != null)
            anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        speed = Input.GetAxis("Vertical");
        direction = Input.GetAxis("Horizontal");

        
        speed *= (Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed);

        anim.SetFloat("speed", speed);


        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * _JumpSpeed * Time.deltaTime);
            anim.SetFloat("speed", jumpSpeed);
            anim.Play("Jump", 0);
        }
        else anim.SetFloat("speed", speed);

        if (speed != 0 && speed <= 0.33f)
        {
            transform.Translate(Vector3.forward * _WalkSpeed * Time.deltaTime);
        }
        else if (speed != 0 && speed >= 0.34f && speed <= 0.8f)
        {
            transform.Translate(Vector3.forward * _RunSpeed * Time.deltaTime);
        }

        if (direction != 0)
        {
           transform.Rotate(Vector3.up, direction * rotateSpeed * Time.deltaTime);
        }

    }


}
