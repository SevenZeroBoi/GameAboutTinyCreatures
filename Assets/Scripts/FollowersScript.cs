using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowersScript : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 subvectorcheck = Vector2.zero;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += subvectorcheck * WalkingScript.instance.moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            Debug.Log("hitcheck");
        }
        if (collision.gameObject.tag == "TURNRIGHT")
        {
            subvectorcheck = Vector2.right;
        }
        if (collision.gameObject.tag == "TURNLEFT")
        {
            subvectorcheck = Vector2.left;
        }
        if (collision.gameObject.tag == "TURNUP")
        {
            subvectorcheck = Vector2.up;
        }
        if (collision.gameObject.tag == "TURNDOWN")
        {
            subvectorcheck = Vector2.down;
        }
    }
}
