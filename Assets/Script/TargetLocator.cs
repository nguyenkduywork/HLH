using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] Transform target;
    [SerializeField] ParticleSystem _particleSystem;

    
    void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
    }

    
    void Update()
    {
        AimWeapon();
    }

    void AimWeapon()
    {
        if (target != null)
        {
            weapon.LookAt(target);
            if(!_particleSystem.isPlaying) _particleSystem.Play();
        }
        else
        {
            if(_particleSystem.isPlaying) _particleSystem.Stop();
        }
    }
}
