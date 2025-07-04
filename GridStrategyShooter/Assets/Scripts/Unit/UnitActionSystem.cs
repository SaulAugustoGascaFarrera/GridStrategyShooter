using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    public event EventHandler OnSelectedUnit;

    public static UnitActionSystem Instance { get; private set; }

    [SerializeField] private Unit selectedUnit;


    [SerializeField] private bool isBusy;

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

    private void Update()
    {
        if (isBusy) return;

        if(Input.GetMouseButtonDown(1))
        {
            selectedUnit.GetSpinAction().Spin(ClearBusy);
            SetBusy();
        }
    }



    private void Instance_OnMove(object sender, EventArgs e)
    {
       

        if (TryGetSelectedUnit() || isBusy) return;

        GridPosition gridPosition = LevelGrid.Instance.GetGridPosition(MouseManager.Instance.GetMouseWorldPosition());

        

        if (selectedUnit.GetMoveAction().IsValidActionAtGridPosition(gridPosition))
        {
            SetBusy();
            selectedUnit.GetMoveAction().Move(gridPosition,ClearBusy);
        }

      

    }

    private void SetBusy()
    {
        isBusy = true;
    }

    private void ClearBusy()
    {
        isBusy = false;
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
