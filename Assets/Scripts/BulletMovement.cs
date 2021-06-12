using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private Transform bulletTransform;

    public float speed;
    public Vector2 direction;

    public float lifetime;
    void Start()
    {
        bulletTransform = GetComponent<Transform>();   
    }

    void FixedUpdate()
    {
        bulletTransform.Translate(direction * speed * Time.deltaTime);
    }
}
