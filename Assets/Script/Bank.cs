using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Bank : MonoBehaviour
{

    [SerializeField] private int startBalance = 100;
    [SerializeField] private int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }

    [SerializeField] private TextMeshProUGUI displayBalance;

    private void Awake()
    {
        currentBalance = startBalance;
        UpdateDisplay();
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();
        if (currentBalance < 0)
        {
            ReloadLevel();
        }
    }

    void UpdateDisplay()
    {
        displayBalance.text = "Gold: " + currentBalance;
    }
    void ReloadLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
    
}
