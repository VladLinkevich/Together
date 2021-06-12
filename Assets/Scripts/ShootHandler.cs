using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootHandler : MonoBehaviour
{
    private TurretsJoint turretsJoint;

    private bool lmbIsDrag;
    void Start()
    {
        turretsJoint = GetComponent<TurretsJoint>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lmbIsDrag = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            lmbIsDrag = false;
        }

        if (lmbIsDrag)
        {
            foreach (TurretManager turret in turretsJoint.turrets)
            {
                turret.shoot();
            }
        }
    }
}
