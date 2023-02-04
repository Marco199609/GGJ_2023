using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 _moveDirection = Vector3.zero;

    public bool Jumping { get; private set; }

    public void Move(CharacterController controller, float speed, float jumpSpeed, float gravity, bool isAttacking)
    {
        if (controller.isGrounded && !isAttacking)
        {
            Jumping = false;

            _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _moveDirection.x *= speed / 2; //El movimento horizontal es mas lento para mayor control
            _moveDirection.z *= speed;

            if (Input.GetButtonDown("Jump"))
            {
                _moveDirection.y = jumpSpeed;
                Jumping = true;
            }            
        }

        if(controller.isGrounded && isAttacking) _moveDirection = Vector3.zero; //Deja de mover si el jugador esta atacando

        _moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(_moveDirection * Time.deltaTime);
    }
}