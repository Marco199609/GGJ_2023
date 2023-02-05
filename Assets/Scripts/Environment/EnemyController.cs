using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private EnemyAnimate _animateScript;
    private EnemyAttack _attackScript;
    private bool _attack;
    private PlayerController _player;

    // Start is called before the first frame update
    void Start()
    {
        _animateScript = GetComponent<EnemyAnimate>();
        _attackScript = GetComponent<EnemyAttack>();
        _player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        var dir = _player.transform.position;
        dir.y = transform.position.y;
        transform.LookAt(dir);
        
        
        if (Vector3.Distance(transform.position, _player.transform.position) < 3)
            _attack = true;
        else
            _attack = false;

        if (_attack)
            _attackScript.Attack();
        
        _animateScript.ActiveAnimation(_player,_attackScript.IsAttacking,animator);
        
    }
}
