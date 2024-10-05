using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingScript : MonoBehaviour
{
    string direction = "";
    Vector3 vectorcheck;
    public int moveSpeed = 1;

    private void Start()
    {
        direction = "START";
    }

    private void Update()
    {
        Movements();
        ChangePosition();
    }

    void Movements()
    {
        if (direction == "START")
        {
            vectorcheck = Vector2.down;
        }
        if (direction == "TURNUP")
        {
            vectorcheck = Vector2.up;
        }
        if (direction == "TURNDOWN")
        {
            vectorcheck = Vector2.down;
        }
        if (direction == "TURNRIGHT")
        {
            vectorcheck = Vector2.right;
        }
        if (direction == "TURNLEFT")
        {
            vectorcheck = Vector2.left;
        }

        transform.position += vectorcheck*moveSpeed*Time.deltaTime;
    }
    void ChangePosition()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = "TURNUP";
            CreaturesTuring();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            direction = "TURNDOWN";
            CreaturesTuring();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction = "TURNRIGHT";
            CreaturesTuring();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction = "TURNLEFT";
            CreaturesTuring();
        }
    }

    public GameObject changeCheck;
    void CreaturesTuring()
    {
        Instantiate(changeCheck,transform.position,Quaternion.identity).tag = direction;
    }
}

