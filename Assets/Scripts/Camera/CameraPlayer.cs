using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField] private Transform _pLayer;
    public Transform _lookTarget; 
    [SerializeField] private Vector3 _followOffset;

    private void LateUpdate()
    {
        transform.position = _pLayer.position + _pLayer.forward * _followOffset.z + _pLayer.up * _followOffset.y;
        transform.LookAt(_lookTarget);
    }
}
