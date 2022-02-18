using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Gold when defeated")] 
    [SerializeField] private int goldReward = 20;
    [Header("Gold taken when enemy reaches the end")]
    [SerializeField] private int goldPenalty = 20;
    
    Bank bank;
    EnemyHealth hp;
    void Start()
    {
        bank = FindObjectOfType<Bank>();
        hp = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        
    }

    public void RewardGold()
    {
        if (bank == null) { return; }
        bank.Deposit(goldReward);
    }

    public void StealGold()
    {
        if (bank == null) { return; }
        if(hp.currentHP >0) bank.Withdraw(goldPenalty);
    }
}
