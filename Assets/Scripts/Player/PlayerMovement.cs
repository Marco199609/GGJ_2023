using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerMove();
        PlayerAnimate();
    }


    private void PlayerMove()
    {
        if (controller.isGrounded)
        {
            jump = false;

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpSpeed;
                jump = true;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }



    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private bool jump, idle, run;

    private void PlayerAnimate()
    {
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            idle = true;
            run = false;
        }

        else
        {
            idle = false;
            run = true;
        }

        _playerAnimator.SetBool("Jump", jump);
        _playerAnimator.SetBool("Run", run);
        _playerAnimator.SetBool("Idle", idle);
    }
}