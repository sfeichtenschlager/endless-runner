using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Vector3 offset = new Vector3(0f, 0f, -5f);
    public float smoothTime = 0.25f;
    public Vector3 velocity = Vector3.zero;

    [SerializeField] public Transform target;
    

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}