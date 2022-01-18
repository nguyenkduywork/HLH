using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHP = 3;
    public int currentHP;
    void OnEnable()
    {
        currentHP = maxHP;
    }


    public int getHP()
    {
        return currentHP;
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHP--;

        if (currentHP <= 0)
        {
            Invoke("SetInactiveEnemy", 1.75f);
        }
    }
    
    void SetInactiveEnemy()
    { 
        gameObject.SetActive(false);
    }
}
