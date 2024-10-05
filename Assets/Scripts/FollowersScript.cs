using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowersScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TURNRIGHT")
        {

        }
        if (collision.gameObject.tag == "TURNLEFT")
        {

        }
        if (collision.gameObject.tag == "TURNUP")
        {

        }
        if (collision.gameObject.tag == "TURNDOWN")
        {

        }
    }
}
