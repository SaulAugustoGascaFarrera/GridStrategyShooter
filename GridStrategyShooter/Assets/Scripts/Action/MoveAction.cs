using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : BaseAction
{
    [Header("Movement Props")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float stoppingDistance = 0.1f;


    private Vector3 targetPosition;

    public override void Awake()
    {
        base.Awake();
        targetPosition = transform.position;
    }

    private void Update()
    {
        Vector3 moveDirection = (targetPosition - transform.position).normalized;

        if(Vector3.Distance(targetPosition,transform.position) > stoppingDistance)
        {
            transform.position += moveDirection * movementSpeed * Time.deltaTime;
        }

        transform.forward += Vector3.Slerp(transform.forward,moveDirection, rotationSpeed * Time.deltaTime);
    }

    public void Move(GridPosition gridPosition)
    {
        targetPosition = LevelGrid.Instance.GetWorldPosition(gridPosition);
    }

    public override string GetActionName()
    {
        return "Move";
    }
}
