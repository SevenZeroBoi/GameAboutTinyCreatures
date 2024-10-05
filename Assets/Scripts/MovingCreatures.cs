using UnityEngine;
using System.Collections.Generic;

public class MovingCreatures : MonoBehaviour
{
    public static MovingCreatures instance;

    private void Awake()
    {
        instance = this;
    }

    float moveSpeed = 4;
    [HideInInspector] public Vector3 rotation = Vector3.down;
    public float followDistance = 1f;

    void Update()
    {
        MoveCreature();
        FollowLeader();
    }

    void MoveCreature()
    {
        transform.position += rotation * moveSpeed * Time.deltaTime;
    }

    void FollowLeader()
    {
        int index = GameStates.instance.creatureStorage.IndexOf(gameObject);

        if (index > 0)
        {
            GameObject leader = GameStates.instance.creatureStorage[index - 1];
            Vector3 leaderPosition = leader.transform.position;

            Vector3 directionToLeader = (leaderPosition - transform.position).normalized;

            if (Vector3.Distance(transform.position, leaderPosition) > followDistance)
            {
                transform.position += directionToLeader * moveSpeed * Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TURNRIGHT")
        {
            transform.position = collision.transform.position;
            rotation = Vector3.right;
            GameStates.instance.rotationObjectStorage[collision.gameObject]--;
        }
        else if (collision.gameObject.tag == "TURNLEFT")
        {
            transform.position = collision.transform.position;
            rotation = Vector3.left;
            GameStates.instance.rotationObjectStorage[collision.gameObject]--;
        }
        else if (collision.gameObject.tag == "TURNUP")
        {
            transform.position = collision.transform.position;
            rotation = Vector3.up;
            GameStates.instance.rotationObjectStorage[collision.gameObject]--;
        }
        else if (collision.gameObject.tag == "TURNDOWN")
        {
            transform.position = collision.transform.position;
            rotation = Vector3.down;
            GameStates.instance.rotationObjectStorage[collision.gameObject]--;
        }
    }
}