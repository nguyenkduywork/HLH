using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    private TextMeshPro label;
    private Vector2Int coordinates;

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        DisplayCoordinates();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
            
    }

    void DisplayCoordinates()
    {
        //Vector2Int only has x and y axis
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        
        //write coordinates in game
        label.text = "(" + coordinates.x + ", " + coordinates.y + ")";
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
