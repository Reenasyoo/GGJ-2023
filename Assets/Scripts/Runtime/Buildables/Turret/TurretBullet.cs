using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    private Transform target;

    public float speed = 1f;

    public int damage = 50;

    public GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    [HideInInspector] public Runtime.Buildables.Turret.TurretAttackController controller;

    void Update()
    {
        if (target == null)
        {
            controller.DeactivateBullet();
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude - 1f <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);

    }
    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);
        Damage(target);
        controller.DeactivateBullet();
    }

    void Damage(Transform enemy)
    {
        //Do damage to enemy
    }
}
