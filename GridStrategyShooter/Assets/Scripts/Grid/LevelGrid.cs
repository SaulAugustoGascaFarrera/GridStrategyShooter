using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    public static LevelGrid Instance {  get; private set; }

    private GridSystem gridSystem;
    [SerializeField] private Transform debugPrefab;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        gridSystem = new GridSystem(10, 10, 2.0f);
        gridSystem.CreateDebugObject(debugPrefab);

        Instance = this;
    }


    public Vector3 GetWorldPosition(GridPosition gridPosition) => gridSystem.GetWorldPosition(gridPosition);

    public GridPosition GetGridPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition);

    public int GetWidth() => gridSystem.GetWidth();

    public int GetHeight() => gridSystem.GetHeight();

    public bool IsValidGridPosition(GridPosition gridPosition) => gridSystem.IsValidGridPosition(gridPosition);

    public GridObject GetGridObject(GridPosition gridPosition) => gridSystem.GetGridObject(gridPosition);

    public void AddUnitAtGridPosition(Unit unit,GridPosition gridPosition)
    {
        GridObject gridObject =  GetGridObject(gridPosition);
        gridObject.AddUnit(unit);
    }

    public void RemoveUnitAtGridPosition(Unit unit, GridPosition gridPosition)
    {
        GridObject gridObject = GetGridObject(gridPosition);
        gridObject.RemoveUnit(unit);
    }

    public void MovedAtGridPosition(Unit unit,GridPosition fromGridPosition,GridPosition toGridPosition)
    {
        RemoveUnitAtGridPosition(unit,fromGridPosition);
        AddUnitAtGridPosition(unit, toGridPosition);

    }

}
