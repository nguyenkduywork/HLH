using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Tower towerPrefabLV1;
    [SerializeField] bool isPlaceable;

    public bool IsPlaceable { get { return isPlaceable; } }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                bool isPlaced = towerPrefabLV1.CreateTower(towerPrefabLV1,transform.position);
                isPlaceable = !isPlaced;
            }
            else
            {
                Debug.Log("This tile is not placeable!");
            }
        }
    }
}
