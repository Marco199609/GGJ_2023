using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] private Transform _followTransform, _lookAtTransform;
    [SerializeField] private Vector3 _followOffset, _lookOffset;
    [SerializeField] private float _followSpeed = 0.3f;
    [SerializeField] private bool _lookAtObject;

    private Vector3 _velocity = Vector3.zero;

    void Update()
    {
        //Define la posicion a seguir
        Vector3 targetPosition = new Vector3(_followTransform.position.x + _followOffset.x, 
            _followTransform.position.y + _followOffset.y, _followTransform.position.z + _followOffset.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, _followSpeed * Time.deltaTime);

        if (_lookAtObject)
        {
            Vector3 targetLookAtPosition = new Vector3(_lookAtTransform.position.x + _lookOffset.x,
                _lookAtTransform.position.y + _lookOffset.y, _lookAtTransform.position.z + _lookOffset.z);

            transform.LookAt(targetLookAtPosition);
        }
    }
}
