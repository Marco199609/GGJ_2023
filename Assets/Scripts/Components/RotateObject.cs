using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private Vector3 _rotate;

    void Update()
    {
        Vector3 rotation = _rotate * Time.deltaTime;

        transform.Rotate(rotation);
    }
}
