using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class WalkingScript : MonoBehaviour
{
    public static WalkingScript instance;

    private void Awake()
    {
        instance = this;
    }

    string direction = "";
    public Vector3 vectorcheck;
    public int moveSpeed;
    public float rangeBetweenCreature;

    private void Start()
    {
        direction = "TURNDOWN";
        vectorcheck = Vector2.down;
        SpawnNextSpawnPoint();
    }

    private void Update()
    {
        Movements();
        ChangePosition();
    }

    public GameObject nextSpawnPoint;
    void Movements()
    {
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

    public void SpawnNextSpawnPoint()
    {
        Instantiate(nextSpawnPoint, transform.position + (rangeBetweenCreature * vectorcheck*-1), Quaternion.identity).tag = direction;
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

