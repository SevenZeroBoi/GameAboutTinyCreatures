using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.Rendering.DebugUI;

public class FollowerScript : MonoBehaviour
{
    /*
    public List<Vector3> wayPointCheck;
    public GameObject mainWayPointTarget;
    private void Start()
    {
        
    }
    private void Update()
    {
        Lining();
    }

    void Spawning()
    {
    }

    void Lining()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameStates.instance.followingPosition.transform.position, MainCharacter.instance.movementSpeed*Time.deltaTime);
    }

    void SetMainTarget()
    {
        GameStates.instance.followersStorage.Add(gameObject);
        mainWayPointTarget = GameStates.instance.followersStorage[GameStates.instance.followersStorage.IndexOf(gameObject) - 1];
    }
    void Walking()
    {
        if (wayPointCheck.Count == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, mainWayPointTarget.transform.position, GameStates.instance.rangeBetweenFollowers);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPointCheck[0], GameStates.instance.rangeBetweenFollowers);
            if (transform.position == wayPointCheck[0])
            {
                wayPointCheck.RemoveAt(0);
            }
        }
    }*/

    public GameObject mainMovingTarget = null;

    GameObject newfollowingPosition;
    private void Start()
    {
        newfollowingPosition = Instantiate(GameStates.instance.followingPosition,transform.position+(angle* GameStates.instance.rangeBetweenFollowers),Quaternion.identity);
    }
    public Vector3 angle = Vector3.right;
    void PositionToFollow()
    {
        newfollowingPosition.transform.position = transform.position + (-1 * GameStates.instance.rangeBetweenFollowers * angle);
        if (transform.position.x == mainMovingTarget.transform.position.x)
        {
            if (transform.position.y > mainMovingTarget.transform.position.y)
            {
                angle = Vector3.up;
            }
            else
            {
                angle = Vector3.down;
            }
        }
        if (transform.position.y == mainMovingTarget.transform.position.y)
        {
            if (transform.position.x > mainMovingTarget.transform.position.x)
            {
                angle = Vector3.right;
            }
            else
            {
                angle = Vector3.left;
            }
        }
    }

    void Patroling()
    {
        
    }
    void LineWalking()
    {
        transform.position = Vector3.MoveTowards(transform.position,mainMovingTarget.transform.position, MainCharacter.instance.movementSpeed*Time.deltaTime);
    }


    private void Update()
    {
        LineWalking();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FOLLOWING")
        {
            mainMovingTarget = collision.gameObject;
        }
    }
}
