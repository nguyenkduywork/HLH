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
    void Start()
    {
        bank = FindObjectOfType<Bank>();
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
        bank.Withdraw(goldPenalty);
    }
}
