using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlling : MonoBehaviour
{
    private void Update()
    {
        Rotation();
    }

    void Rotation()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            GameStates.instance.rotationPoint[transform.position] = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            GameStates.instance.rotationPoint[transform.position] = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            GameStates.instance.rotationPoint[transform.position] = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            GameStates.instance.rotationPoint[transform.position] = Vector2.up;
        }
    }
}
