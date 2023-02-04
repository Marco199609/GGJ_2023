using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 moveDirection = Vector3.zero;
    public bool Jumping { get; private set; }

    public void Move(CharacterController controller, float speed, float jumpSpeed, float gravity, bool isAttacking)
    {
        if (controller.isGrounded && !isAttacking)
        {
            Jumping = false;

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpSpeed;
                Jumping = true;
            }
        }
        if(controller.isGrounded && isAttacking)
        {
            moveDirection = Vector3.zero; //Deja de mover si el jugador esta atacando
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}