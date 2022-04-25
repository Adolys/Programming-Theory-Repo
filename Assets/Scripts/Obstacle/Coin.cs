using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Obstacle
{
    public float degreePerSecond = 20.0f;
    

    protected override void OnUnitAction()
    {
        base.OnUnitAction();

        transform.Rotate(Vector3.up, Time.deltaTime * degreePerSecond);
    }
}
