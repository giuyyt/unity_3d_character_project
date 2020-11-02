using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMove : MonoBehaviour
{
    public Transform playerTransform;
    public float smoothing;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    void Update()//update表示平台的帧数而fixedupdate表示现实时间的时间
    {
        Vector3 newCameraPos = playerTransform.position + offset;
        transform.position = Vector3.Lerp(transform.position, newCameraPos, smoothing * Time.deltaTime);

    }

}