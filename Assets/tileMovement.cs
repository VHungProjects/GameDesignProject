
using System;
using Unity.Mathematics;
using UnityEngine;

public class tileMovement : MonoBehaviour
{
   private const float tolerance = 0.1f;

    public void moveUp()
    {
        float zRotation = transform.eulerAngles.z;

        if (Mathf.Abs(zRotation - 0) < tolerance)
        {
            transform.position += new Vector3(0, 10, 0);
        }
        else if (Mathf.Abs(zRotation - 90) < tolerance)
        {
            transform.position += new Vector3(-10, 0, 0);
        }
        else if (Mathf.Abs(zRotation - 180) < tolerance)
        {
            transform.position += new Vector3(0, -10, 0);
        }
        else if (Mathf.Abs(zRotation - 270) < tolerance)
        {
            transform.position += new Vector3(10, 0, 0);
        }
    }
}
