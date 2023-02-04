using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    private bool _idle, _run;

    public void Animate(bool jump, bool isAttacking, Animator playerAnimator)
    {

        MoveAnimation(jump, playerAnimator);
        AttackAnimation(isAttacking, playerAnimator);
    }

    private void MoveAnimation(bool jump, Animator playerAnimator)
    {
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            _idle = true;
            _run = false;
        }

        else
        {
            _idle = false;
            _run = true;
        }

        playerAnimator.SetBool("Jump", jump);
        playerAnimator.SetBool("Run", _run);
        playerAnimator.SetBool("Idle", _idle);
    }

    private void AttackAnimation(bool isAttacking, Animator playerAnimator)
    {
        playerAnimator.SetBool("Attack", isAttacking);
    }
}
