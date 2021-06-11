using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretsJoint : MonoBehaviour
{
    private Transform playerTransform;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Turret"))
        {
            collision.transform.parent = playerTransform;
            collision.transform.tag = "Player";
        }
    }

    void Start()
    {
        playerTransform = GetComponent<Transform>();
    }

    void Update()
    {
        
    }
}
