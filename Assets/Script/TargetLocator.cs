using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [Header("Weapon prefab to make it rotates")]
    [SerializeField] Transform weapon;
    [Header("add Particle System here")]
    [SerializeField] ParticleSystem _particleSystem;
    [Header("Tower range")]
    [SerializeField] private float range = 20f;
    Transform target;
    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            //if enemy hp is 0 then stop looking at it
            if (enemy.GetComponent<EnemyHealth>().getHP() > 0)
            {
                //calculate distance between tower and enemies
                float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
                if (targetDistance < maxDistance)
                {
                    closestTarget = enemy.transform;
                    maxDistance = targetDistance;
                }
            }
        }
        //assign closest target for towers to shoot
        target = closestTarget;
    }

    void AimWeapon()
    {
        try
        {
            float targetDistance = Vector3.Distance(transform.position, target.position);
            weapon.LookAt(target);
            if (targetDistance <= range)
            {
                Attack(true);
            }
            else
            {
                Attack(false);
            }
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine(e);
        }
    }

    
    //Turn off particle system when no enemy is present/ enemy out of range
    void Attack(bool isActive)
    {
        var emissionModule = _particleSystem.emission;
        emissionModule.enabled = isActive;
    }
}
