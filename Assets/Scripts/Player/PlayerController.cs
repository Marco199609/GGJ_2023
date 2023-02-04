using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerRotation))]
[RequireComponent(typeof(PlayerAnimate))]
[RequireComponent(typeof(PlayerAttack))]
public class PlayerController : MonoBehaviour
{
    [Header("Variables de movimiento")]
    [SerializeField] private float _speed = 12.0f;
    [SerializeField] private float _jumpSpeed = 8.0f;
    [SerializeField] private float _gravity = 20.0f;
    private CharacterController _controller;

    [Header("Variables de animación")]
    [SerializeField] private Animator _playerAnimator;

    private PlayerMovement _playerMovement;
    private PlayerRotation _playerRotation;
    private PlayerAnimate _playerAnimate;
    private PlayerAttack _playerAttack;


    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerRotation = GetComponent<PlayerRotation>();
        _playerAnimate = GetComponent<PlayerAnimate>();
        _playerAttack = GetComponent<PlayerAttack>();

        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerMovement.Move(_controller, _speed, _jumpSpeed, _gravity, _playerAttack.IsAttacking);
        _playerRotation.Rotate();
        _playerAttack.Attack(_playerMovement.Jumping);
        _playerAnimate.Animate(_playerMovement.Jumping, _playerAttack.IsAttacking, _playerAnimator);
    }
}
