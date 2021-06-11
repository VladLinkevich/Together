using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform playerTransform;

    public float speed;

    private Vector2 direction;
    private void Start()
    {
        playerTransform = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        playerTransform.Translate(direction * speed * Time.deltaTime);
    }
}
