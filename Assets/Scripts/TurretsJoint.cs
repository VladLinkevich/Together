using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretsJoint : MonoBehaviour
{
    private Transform playerTransform;

    public TurretManager startTurret;

    private List<TurretManager> turrets;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Turret"))
        {
            bool isDeleted = false;

            TurretManager turret = collision.gameObject.GetComponent<TurretManager>();

            turret.transform.tag = "Player";

            foreach (TurretManager trt in turrets)
            {
                if (trt.level == turret.level)
                {
                    isDeleted = true;
                    turret.destroy();
                    trt.addLevel();
                }
            }    
            
            if (!isDeleted)
            {
                turrets.Add(turret);
                connectTurret(turret);
            }
        }
    }

    void Start()
    {
        playerTransform = GetComponent<Transform>();
        turrets = new List<TurretManager>();

        turrets.Add(startTurret);
    }

    void connectTurret(TurretManager turret)
    {
        Transform turretTransform = turret.transform;

        turretTransform.parent = playerTransform;

        turret.offset.x = Mathf.RoundToInt(turretTransform.localPosition.x);
        turret.offset.y = Mathf.RoundToInt(turretTransform.localPosition.y);
        turretTransform.localPosition = turret.offset;
    }
}
