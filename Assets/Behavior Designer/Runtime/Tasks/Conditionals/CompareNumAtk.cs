using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class CompareNumAtk : Conditional
{
    private SharedInt variable;
    public SharedInt compareTo;
    public BehaviorTree bt;

    public override TaskStatus OnUpdate()
    {
        variable = (SharedInt)bt.GetVariable("numAtk");

        if (variable.Value >= compareTo.Value)
        {
            return TaskStatus.Failure;
        }
        else
        {
            return TaskStatus.Success;
        }
    }

    public override void OnReset()
    {
        compareTo = 3;
    }
}



