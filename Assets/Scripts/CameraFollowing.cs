using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    private Transform cameraTransform;

    public Transform objectTransform;
    public float offsetX;
    public float offsetY;

    public float speedCameraFollowing;

    void Start()
    {
        cameraTransform = GetComponent<Transform>();
    }

    void FixedUpdate()
    {  
        cameraTransform.position = new Vector3(Mathf.Lerp(cameraTransform.position.x, 
            objectTransform.position.x + offsetX, speedCameraFollowing * Time.deltaTime), 
            Mathf.Lerp(cameraTransform.position.y, objectTransform.position.y + offsetY, speedCameraFollowing * Time.deltaTime), 
            cameraTransform.position.z);
    }
}
