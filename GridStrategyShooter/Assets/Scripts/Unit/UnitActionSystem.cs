using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    public event EventHandler OnSelectedUnit;

    public static UnitActionSystem Instance { get; private set; }

    [SerializeField] private Unit selectedUnit;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        GameInput.Instance.OnMove += Instance_OnMove;
    }

    private void Instance_OnMove(object sender, EventArgs e)
    {
        if (!selectedUnit || TryGetSelectedUnit()) return;

        GridPosition gridPosition = LevelGrid.Instance.GetGridPosition(MouseManager.Instance.GetMouseWorldPosition());

       selectedUnit.GetMoveAction().Move(gridPosition);

    }


    public bool TryGetSelectedUnit()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit hit,float.MaxValue,1 << 7))
        {
            if(hit.transform.gameObject.TryGetComponent(out Unit unit))
            {

                SetSelectedUnit(unit);

                return true;
            }
        }

        return false;
    }



    public Unit GetSelectedUnit()
    {
         return selectedUnit;
    }

    public void SetSelectedUnit(Unit newSelectedUnit)
    {
        selectedUnit = newSelectedUnit;

        OnSelectedUnit?.Invoke(this, EventArgs.Empty);
    }

}
