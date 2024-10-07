using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.Rendering.DebugUI;

public class FollowerScript : MonoBehaviour
{
    void AfterSpawning()
    {

    }

    [HideInInspector] public GameObject objectFollower;

    public List<GameObject> subTargetList;
    public GameObject mainTarget;
    public Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.applyRootMotion = false;
    }
    public string stage = "WALKING";
    int rotation = -1;
    public float startingspeed;
    private void Update()
    {
        animtimecheck+=Time.deltaTime;
        if (animtimecheck > 2)
        {
            transform.rotation = Quaternion.Euler(0, 0, 20*rotation);
            rotation*=-1;
            animtimecheck = 0;
        }
        if (stage == "LINE")
        {
            InlineMovement();
        }
        else if (stage == "WALKING")
        {
            transform.position += Time.deltaTime * startingspeed * Vector3.up;
        }
        else if (stage == "DEATH"){
            OnDeath();
        }/*
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("DeathEnd"))
        {
            gameObject.SetActive(false);
        }
        */
    }
    Vector3 vectorcheck = Vector3.down;

    float animtimecheck = 0;
    void OnDeath()
    {
        
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, GameStates.instance.deathLocation.transform.position, Time.deltaTime * 17);
        if (transform.position == GameStates.instance.deathLocation.transform.position)
        {
            Destroy(gameObject);
        }
    }
    void InlineMovement() //movement when hit the target followeing
    {
        objectFollower.transform.position = transform.position + (-1 * GameStates.instance.rangeBetweenFollowers * vectorcheck);
        if (subTargetList.Count == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, mainTarget.transform.position, (GameStates.instance.movementSpeed + 0.1f) * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, subTargetList[0].transform.position, (GameStates.instance.movementSpeed + 0.1f) * Time.deltaTime);
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
        if (collision.gameObject.tag == "CANFOLLOW" && stage != "LINE")
        {
            GameStates.instance.allFollowersStorage.Add(gameObject);
            mainTarget = collision.gameObject;
            collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            objectFollower = Instantiate(GameStates.instance.objectFollowerPrefab);
            GameStates.instance.allFollowingDetection.Add(objectFollower);
            objectFollower.transform.position = transform.position + (-1 * GameStates.instance.rangeBetweenFollowers * vectorcheck);
            vectorcheck = MainCharacter.instance.rotationPos;
            gameObject.tag = "SETNEWONE";

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
            else if (gameObject.name == "NORMAL")
            {
                GameStates.instance.normalCount++;
            }
            else if (gameObject.name == "NERD")
            {
                GameStates.instance.nerdCount++;
            }
            else if (gameObject.name == "HEART")
            {
                GameStates.instance.heartCount++;
            }
            else if (gameObject.name == "FLOWER")
            {
                GameStates.instance.flowerCount++;
            }
            else if (gameObject.name == "BUG")
            {
                GameStates.instance.bugCount++;
            }
            else if (gameObject.name == "CLOUD")
            {
                GameStates.instance.cloudCount++;
            }
            else if (gameObject.name == "FIRE")
            {
                GameStates.instance.fireCount++;
            }


            stage = "LINE";
        }

        if (collision.gameObject.tag == "CREATURES")
        {
            GameStates.instance.CreaturesDeath(gameObject);
        }
    }
}