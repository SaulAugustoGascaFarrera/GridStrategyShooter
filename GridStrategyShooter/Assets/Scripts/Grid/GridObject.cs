using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GridObject
{
   private GridSystem gridSystem;
   private GridPosition gridPosition;
    public List<Unit> unitList;

   public GridObject(GridSystem gridSystem, GridPosition gridPosition)
   {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
        unitList = new List<Unit>();
   }

    public override string ToString()
    {
        string unitString = "";

        if(HasAnyUnit())
        {
            foreach(Unit unit in unitList)
            {
                unitString += unit.ToString() + "\n";
            }

            return gridPosition.ToString() + "\n" + unitString;
        }

        return gridPosition.ToString();
    }

    public void AddUnit(Unit unit)
    {
        unitList.Add(unit);
    }

    public List<Unit> GetUnitList()
    {
        return unitList;
    }

    public void RemoveUnit(Unit unit)
    {
        unitList.Remove(unit);
    }

    public bool HasAnyUnit()
    {
        return unitList.Count > 0;
    }

}
