using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.Rendering.DebugUI;

public class FollowerScript : MonoBehaviour
{
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
    }
}
