using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    private GridPosition gridPosition;


    private MoveAction moveAction;
    private SpinAction spinAction;
    private void Awake()
    {
        moveAction = GetComponent<MoveAction>();
        spinAction = GetComponent<SpinAction>();
    }

    void Start()
    {
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(this, gridPosition);
    }

    // Update is called once per frame
    void Update()
    {
        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);

        if(newGridPosition != gridPosition)
        {
            LevelGrid.Instance.MovedAtGridPosition(this, gridPosition, newGridPosition);

            gridPosition = newGridPosition;
        }

        //Debug.Log(GetGridPosition() + new GridPosition(-2,-2));
    }


    public GridPosition GetGridPosition()
    { 
        return gridPosition; 
    }

    public MoveAction GetMoveAction()
    {
        return moveAction;
    }
}
