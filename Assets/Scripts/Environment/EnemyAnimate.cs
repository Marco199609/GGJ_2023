using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimate : MonoBehaviour
{
    private bool _ground;
    private bool _idle;
    public void ActiveAnimation(PlayerController player, bool isAttack, Animator enemyAnimator)
    {
        if (Vector3.Distance(transform.position,player.transform.position)< 5)
        {
            _ground = false;
            _idle = true;
        }
        else
        {
            _ground = true;
            _idle = false;
        }
        
        
        
        enemyAnimator.SetBool("Idle", _idle);
        enemyAnimator.SetBool("Attack", isAttack);
        //enemyAnimator.SetBool("Ground", _ground);
        
    }
    
    
}
