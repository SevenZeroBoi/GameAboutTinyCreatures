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

    [HideInInspector]  public GameObject objectFollower;

    [HideInInspector] public List<GameObject> subTargetList;
    [HideInInspector] public GameObject mainTarget;
    public Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private bool canwalk = false;
    private void Update()
    {
        if (canwalk)
        {
            InlineMovement();
        }/*
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("DeathEnd"))
        {
            PoolingManager.instance.ReturnToPool(gameObject.name, gameObject);
        }*/
    }
    Vector3 vectorcheck = Vector3.down;
    void InlineMovement() //movement when hit the target followeing
    {
        objectFollower.transform.position = transform.position + (-1 * GameStates.instance.rangeBetweenFollowers * vectorcheck);
        if (subTargetList.Count == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, mainTarget.transform.position, (GameStates.instance.movementSpeed+ 0.1f) * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, subTargetList[0].transform.position, (GameStates.instance.movementSpeed+ 0.1f) * Time.deltaTime);
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
                subTargetList[0].GetComponent<RotateCheckDelete>().checkingcount--;
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
            collision.gameObject.GetComponent<Animator>().enabled = true;
            GameObject objectFollower = Instantiate(GameStates.instance.objectFollowerPrefab, transform.position, Quaternion.identity);
            objectFollower.transform.position = transform.position + (-1 * GameStates.instance.rangeBetweenFollowers * vectorcheck);
            vectorcheck = MainCharacter.instance.rotationPos;

            if (gameObject.name == "RUNNER")
            {
                GameStates.instance.normalSpeed *= 0.2f;
            }
            else if (gameObject.name == "ROCK")
            {
                GameStates.instance.normalSpeed /= 0.2f;
            }
            else if (gameObject.name == "ROCKET")
            {
                GameStates.instance.OverallScoreMultiply += 0.2f;
            }
            else if (gameObject.name == "STAR")
            {
                GameStates.instance.OverallScoreMultiply += 1;
            }



            canwalk = true;
        }

        if (collision.gameObject.tag == "ATTACK")
        {
            GameStates.instance.CreaturesDeath(gameObject);
        }
    }
}
