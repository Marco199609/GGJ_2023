using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerAnimate))]
[RequireComponent(typeof(PlayerAttack))]
public class PlayerController : MonoBehaviour
{
    [Header("Variables de movimiento")]
    [SerializeField] private float speed = 12.0f;
    [SerializeField] private float jumpSpeed = 8.0f;
    [SerializeField] private float gravity = 20.0f;
    private CharacterController _controller;

    [Header("Variables de animación")]
    [SerializeField] private Animator _playerAnimator;



    private PlayerMovement _playerMovement;
    private PlayerAnimate _playerAnimate;
    private PlayerAttack _playerAttack;


    // Start is called before the first frame update
    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAnimate = GetComponent<PlayerAnimate>();
        _playerAttack = GetComponent<PlayerAttack>();

        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerMovement.Move(_controller, speed, jumpSpeed, gravity, _playerAttack.IsAttacking);

        _playerAttack.Attack(_playerMovement.Jumping);

        _playerAnimate.Animate(_playerMovement.Jumping, _playerAttack.IsAttacking, _playerAnimator);
    }
}
