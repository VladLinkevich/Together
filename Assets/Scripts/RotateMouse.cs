using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMouse : MonoBehaviour
{
    private Transform playerTransform;
    private Camera cameraMain;

    public float rotateSpeed;

    private Vector3 mousePosition;

    private Vector2 targetDestination;
    private float targetRotation;

    void Start()
    {
        playerTransform = GetComponent<Transform>();

        cameraMain = Camera.main;
    }

    void FixedUpdate()
    {
        mousePosition = cameraMain.ScreenToWorldPoint(Input.mousePosition);

        targetDestination = mousePosition - playerTransform.position;
        targetRotation = Mathf.Atan2(targetDestination.y, targetDestination.x) * Mathf.Rad2Deg;
        playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, 
            Quaternion.AngleAxis(targetRotation, Vector3.forward), rotateSpeed * Time.deltaTime);
    }
}
