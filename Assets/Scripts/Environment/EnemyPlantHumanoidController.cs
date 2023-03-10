using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlantHumanoidController : MonoBehaviour
{
    private Animator _animator;
    private PlayerController _playerController;
    private bool attack;
    private bool run;

    [SerializeField] private float enemyDamage, damageTimer = 1.3f;
    private float enemyDamageTimer = 1.3f;

    void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(_playerController.transform.position, transform.position)<10 && Vector3.Distance(_playerController.transform.position, transform.position)>2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _playerController.transform.position, 1.5f*Time.deltaTime);
            var dir = _playerController.transform.position;
            dir.y = transform.position.y;
            transform.LookAt(dir);
            run = true;
        }
        else
        {
            run = false;
        }

        if (Vector3.Distance(_playerController.transform.position, transform.position) < 2f)
        {
            attack = true;


            //Limita el ataque del enemigo
            enemyDamageTimer -= Time.deltaTime;

            if(enemyDamageTimer <= 0)
            {
                var healthPlayer = _playerController.GetComponent<HealthComponent>();
                if (healthPlayer.shield > 0)
                    healthPlayer.shield -= enemyDamage;
                else
                    healthPlayer.health -= (int) enemyDamage;
                enemyDamageTimer = 1.3f;

            }

            print(enemyDamageTimer);
        }
        else
            attack = false;
        AnimateAttack();
    }


    public void AnimateAttack()
    {
        if (attack)
            _animator.SetInteger("State",3);//animacion de ataque se activa
        else if (!run)
        {
            _animator.SetInteger("State",1);//idle se activa
        }else
            _animator.SetInteger("State",2);//animacion de run se activa
    }
    
}
