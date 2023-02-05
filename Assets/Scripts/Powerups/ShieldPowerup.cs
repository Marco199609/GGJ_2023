using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerup : MonoBehaviour
{
    [SerializeField] private int _shieldPowerup;
    [SerializeField] private AudioClip _powerupClip;
    [SerializeField] private AudioSource _audioSource;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<HealthComponent>().shield += _shieldPowerup;
            _audioSource = GameObject.FindGameObjectWithTag("Powerup").GetComponent<AudioSource>();
            _audioSource.PlayOneShot(_powerupClip);
            Destroy(gameObject);
        }
    }
}
