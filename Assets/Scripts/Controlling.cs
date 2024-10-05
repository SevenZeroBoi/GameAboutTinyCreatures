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
            Instantiate(GameStates.instance.objectToRotate,transform.position,Quaternion.identity).tag = "TURNRIGHT";
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(GameStates.instance.objectToRotate, transform.position, Quaternion.identity).tag = "TURNLEFT";
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(GameStates.instance.objectToRotate, transform.position, Quaternion.identity).tag = "TURNDOWN";
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Instantiate(GameStates.instance.objectToRotate, transform.position, Quaternion.identity).tag = "TURNUP";
        }
    }
}
