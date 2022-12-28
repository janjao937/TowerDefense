using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateText : MonoBehaviour
{
    private TextMeshPro text;
    private Vector2Int coordinate = new Vector2Int();
    private void Awake() 
    {
        text = GetComponent<TextMeshPro>();
        DisplayCoordinateText();
    }
    private void Update() 
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinateText();
            UpdateObjectName();
        }
    }

    private void DisplayCoordinateText()
    {
        coordinate.x = Mathf.RoundToInt(transform.parent.position.x/UnityEditor.EditorSnapSettings.move.x);
        coordinate.y = Mathf.RoundToInt(transform.parent.position.z/UnityEditor.EditorSnapSettings.move.z);
        text.text = $"{coordinate.x},{coordinate.y}";
    }
    private void UpdateObjectName()
    {
        transform.parent.name = coordinate.ToString();
    }
}
