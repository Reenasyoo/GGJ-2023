using System;
using Runtime.Buildables.Turret;
using Runtime.Enemy;
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

    [HideInInspector] public TurretAttackController controller;

    void Update()
    {
        if (target == null)
        {
            controller.DeactivateBullet();
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        // if (dir.magnitude - 1f <= distanceThisFrame)
        // {
        //     HitTarget();
        //     return;
        // }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);

    }
    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);
        controller.DeactivateBullet();
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            HitTarget();
            var enemy = other.GetComponent<EnemyFacade>();
            enemy.TakeDamage(-20);
        }
    }
}
