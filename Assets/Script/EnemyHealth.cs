using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHP = 3;
    [Tooltip("Adds amount to maxHP when enemy dies")]
    [SerializeField] private int difficultyRamp = 1;
    public int currentHP;
    
    private Enemy enemy;
    void OnEnable()
    {
        currentHP = maxHP;
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
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
            //reward gold when defeated
            
            enemy.RewardGold();
            maxHP += difficultyRamp;
            enemy.GetComponent<BoxCollider>().enabled = false;
            Invoke("SetInactiveEnemy", 1.75f);
        }
    }
    
    void SetInactiveEnemy()
    {
        enemy.GetComponent<BoxCollider>().enabled = true;
        gameObject.SetActive(false);
    }
}
