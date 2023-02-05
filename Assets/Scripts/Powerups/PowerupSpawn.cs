using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _powerup;
    private void OnDestroy()
    {
        if (!this.gameObject.scene.isLoaded) return;
        Instantiate(_powerup, new Vector3(transform.position.x, 1.5f, transform.position.z), Quaternion.identity);
    }
}
