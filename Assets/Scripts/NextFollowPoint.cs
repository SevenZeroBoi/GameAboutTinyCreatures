using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class NextFollowPoint : MonoBehaviour
{
    Vector3 movingPos;
    private void Awake()
    {
        if (gameObject.tag == "TURNUP")
        {
            movingPos = Vector2.up;
        }
        if (gameObject.tag == "TURNDOWN")
        {
            movingPos = Vector2.down;
        }
        if (gameObject.tag == "TURNRIGHT")
        {
            movingPos = Vector2.right;
        }
        if (gameObject.tag == "TURNLEFT")
        {
            movingPos = Vector2.left;
        }
    }

    private void Start()
    {
        gameObject.tag = "SETNEWONE";
    }

    private void Update()
    {
        transform.position += (movingPos * WalkingScript.instance.moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TURNRIGHT")
        {
            movingPos = Vector2.right;
        }
        if (collision.gameObject.tag == "TURNLEFT")
        {
            movingPos = Vector2.left;
        }
        if (collision.gameObject.tag == "TURNUP")
        {
            movingPos = Vector2.up;
        }
        if (collision.gameObject.tag == "TURNDOWN")
        {
            movingPos = Vector2.down;
        }
    }

}
