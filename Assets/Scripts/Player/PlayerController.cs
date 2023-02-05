using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerRotation))]
[RequireComponent(typeof(PlayerAnimate))]
[RequireComponent(typeof(PlayerAttack))]
[RequireComponent(typeof(PlayerUI))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _playerDamage = 20;

    [Header("Variables de movimiento")]
    [SerializeField] private float _speed = 12.0f;
    [SerializeField] private float _jumpSpeed = 8.0f;
    [SerializeField] private float _gravity = 20.0f;
    [SerializeField] private GameObject _playerModel;
    private CharacterController _controller;

    [Header("Variables de animación")]
    [SerializeField] private Animator _playerAnimator;

    private PlayerMovement _playerMovement;
    private PlayerRotation _playerRotation;
    private PlayerAnimate _playerAnimate;
    private PlayerAttack _playerAttack;
    private PlayerUI _playerUI;

    [Header("Variables de camara")]
    [SerializeField] private GameObject _virtualCam;

    [Header("Variables de interfaz")]
    [SerializeField] private GameObject _shieldFill;
    [SerializeField] private GameObject[] _UIImages;
    [SerializeField] private GameObject _enemyUI;
    [SerializeField] private GameObject _enemyUIHealth;

    [Header("Variables de sonido")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _attackSound;

    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerRotation = GetComponent<PlayerRotation>();
        _playerAnimate = GetComponent<PlayerAnimate>();
        _playerAttack = GetComponent<PlayerAttack>();
        _playerUI = GetComponent<PlayerUI>();

        _controller = GetComponent<CharacterController>();


    }

    // Update is called once per frame
    void Update()
    {
        _playerMovement.Move(_controller, _speed, _jumpSpeed, _gravity, _playerAttack.IsAttacking);
        _playerRotation.Rotate(_playerModel, _virtualCam);
        _playerAttack.Attack(_playerModel, _playerMovement.Jumping, _playerDamage, _audioSource, _attackSound);
        _playerAnimate.Animate(_playerMovement.Jumping, _playerAttack.IsAttacking, _playerAnimator);
        _playerUI.UpdateUI(_UIImages, _playerModel, _shieldFill, GetComponent<HealthComponent>(), _enemyUI, _enemyUIHealth);
    }
}
