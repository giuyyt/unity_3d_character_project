using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript2 : MonoBehaviour
{

    public Transform playerTransform;
    public float smoothing;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newCameraPos = playerTransform.position + offset;
        transform.position = newCameraPos;
    }
}
