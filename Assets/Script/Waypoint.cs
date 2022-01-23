using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private GameObject[] towerPrefabs;
    [SerializeField] bool isPlaceable;
    [SerializeField] private int costLV1 = 50;
    [SerializeField] private int costLV2 = 100;
    [SerializeField] private int costLV3 = 150;
    private Bank bank;
    private GameObject tower;
    private bool isUpgraded = false;
    private int lv = 0;
    public bool IsPlaceable { get { return isPlaceable; } }
    

    private void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
           BuildTower();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            UpgradeTower();
        }
    }

    private void BuildTower()
    {
        if(bank.CurrentBalance < costLV1) print("Not enough money to build");
        else if (!isPlaceable)
        {
            print("This tile is not placeable!");
        }
        else
        {
            GameObject _tower = Instantiate(towerPrefabs[0], transform.position, Quaternion.identity);
            tower = _tower;
            bank.Withdraw(costLV1);
            isPlaceable = false;
            lv++;
        }
    }

    private void UpgradeTower()
    {
        if(bank.CurrentBalance < costLV2 || lv==3) print("Not allowed");
        else if(bank.CurrentBalance >= costLV2 && lv==1)
        {
            Destroy(tower);
            GameObject _tower = Instantiate(towerPrefabs[1], transform.position, Quaternion.identity);
            tower = _tower;
            bank.Withdraw(costLV2);
            isUpgraded = true;
            lv++;
        }
        else if (bank.CurrentBalance >= costLV3 && lv == 2)
        {
            Destroy(tower);
            GameObject _tower =  Instantiate(towerPrefabs[2], transform.position, Quaternion.identity);
            tower = _tower;
            bank.Withdraw(costLV3);
            isUpgraded = true;
            lv++;
        }
    }
}
