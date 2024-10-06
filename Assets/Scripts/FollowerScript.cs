using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.Rendering.DebugUI;

public class FollowerScript : MonoBehaviour
{
    void AfterSpawning()
    {

    }

    public GameObject objectFollower;

    public List<GameObject> subTargetList;
    public GameObject mainTarget;
    private void Start()
    {
        objectFollower.transform.position = transform.position + (-1 * GameStates.instance.rangeBetweenFollowers * Vector3.right);
    }
    private bool canwalk = false;
    private void Update()
    {
        if (canwalk)
        {
            InlineMovement();
        }
    }
    Vector3 vectorcheck = Vector3.down;
    void InlineMovement() //movement when hit the target followeing
    {
        objectFollower.transform.position = transform.position + (-1 * GameStates.instance.rangeBetweenFollowers * vectorcheck);
        if (subTargetList.Count == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, mainTarget.transform.position, GameStates.instance.movementSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, subTargetList[0].transform.position, GameStates.instance.movementSpeed * Time.deltaTime);
            if (transform.position == subTargetList[0].transform.position)
            {
                if (subTargetList[0].tag == "RIGHT")
                {
                    vectorcheck = Vector3.right;
                }
                else if (subTargetList[0].tag == "LEFT")
                {
                    vectorcheck = Vector3.left;
                }
                else if (subTargetList[0].tag == "DOWN")
                {
                    vectorcheck = Vector3.down;
                }
                else if (subTargetList[0].tag == "UP")
                {
                    vectorcheck = Vector3.up;
                }
                subTargetList.RemoveAt(0);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CANFOLLOW" && !canwalk)
        {
            GameStates.instance.allFollowersStorage.Add(gameObject);
            mainTarget = collision.gameObject;
            collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            canwalk = true;
        }
    }
}
