using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0f, 0f, 0f);

    private Vector3 _velocity = Vector3.zero;
    private float _smothSpeed = 0.125f;
    private void Update()
    {
        transform.position = target.position + offset;
        
        //
        // Vector3 desiredPosition = target.position + offset;
        // transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref _velocity, 
        //     _smothSpeed);

        // Vector3 desiredPosition = target.position + offset;
        // Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, _smothSpeed);
        // transform.position = smoothPosition;
        //
        // transform.LookAt(target);
    }
}
