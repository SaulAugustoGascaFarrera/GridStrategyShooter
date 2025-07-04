using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SpinAction : BaseAction
{

    //public delegate void SpinCompleteDelegate();

    private float totalSpinAmount = 0;

    //public Action onSpinComplete;


    public override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        if(!isActive)
        {
            return;
        }

        float spinAddAmount = 360.0f * Time.deltaTime;
        transform.eulerAngles += new Vector3(0, spinAddAmount, 0);

        totalSpinAmount += spinAddAmount;

        if(totalSpinAmount >= 360.0f)
        {
            totalSpinAmount = 0.0f;
            isActive = false;
            onActionComplete();
        }
    }

    public void Spin(Action onActionComplete)
    {
        this.onActionComplete = onActionComplete;
        isActive = true;
    }

    public override string GetActionName()
    {
        return "Spin";
    }
}
