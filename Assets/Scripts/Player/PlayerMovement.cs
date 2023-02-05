using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 _moveDirection = Vector3.zero;

    public bool Jumping { get; private set; }

    public void Move(CharacterController controller, float speed, float jumpSpeed, float gravity, bool isAttacking)
    {
        if (controller.isGrounded && !isAttacking)
        {
            Jumping = false;

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            _moveDirection = (Camera.main.transform.right * horizontal + Camera.main.transform.forward * vertical).normalized * speed;

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