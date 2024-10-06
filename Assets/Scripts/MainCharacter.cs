using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.PlayerSettings;

public class MainCharacter : MonoBehaviour
{

    public GameObject objectFollower;

    private void Start()
    {
        objectFollower.transform.position = transform.position + (-1 * GameStates.instance.rangeBetweenFollowers * Vector3.right);
    }

    private void Update()
    {
        Movement();
    }


    public Vector3 rotationPos = Vector3.down;
    void Movement() //main movement
    {
        transform.position += rotationPos * GameStates.instance.movementSpeed * Time.deltaTime;
        objectFollower.transform.position = transform.position + (-1 * GameStates.instance.rangeBetweenFollowers * rotationPos);
        if (rotationPos != Vector3.left && rotationPos != Vector3.right)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                rotationPos = Vector3.right;
                CreateRotationPos(rotationPos);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                rotationPos = Vector3.left;
                CreateRotationPos(rotationPos);
            }
        }
        if (rotationPos != Vector3.up && rotationPos != Vector3.down)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rotationPos = Vector3.up;
                CreateRotationPos(rotationPos);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                rotationPos = Vector3.down;
                CreateRotationPos(rotationPos);
            }
        }
    }

    public GameObject emptyPos;
    void CreateRotationPos(Vector3 pos) //send rotation pos when that location
    {
        if (GameStates.instance.allFollowersStorage.Count != 0)
        {
            GameObject newemptyPos = Instantiate(emptyPos, transform.position, Quaternion.identity);
            if (pos == Vector3.right)
            {
                newemptyPos.tag = "RIGHT";
            }
            else if (pos == Vector3.left)
            {
                newemptyPos.tag = "LEFT";
            }
            else if (pos == Vector3.up)
            {
                newemptyPos.tag = "UP";
            }
            else if (pos == Vector3.down)
            {
                newemptyPos.tag = "DOWN";
            }
            GameStates.instance.AddEveryFollowerTarget(newemptyPos);
        }
    }
}
