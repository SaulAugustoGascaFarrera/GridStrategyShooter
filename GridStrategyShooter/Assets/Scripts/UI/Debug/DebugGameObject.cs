using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugGameObject : MonoBehaviour
{
    [SerializeField] private TextMeshPro txtMeshPro;
    private GridObject gridObject;
   
    public void SetGridObject(GridObject newGridObject)
    {
        gridObject = newGridObject;
    }

    private void Update()
    {
        txtMeshPro.text = gridObject.ToString();
    }
}
