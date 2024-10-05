using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TurningScript : MonoBehaviour
{
    int followerCounts = 0;
    int checkingCounts = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CREATURES")
        {
            checkingCounts++;
        }
        if (followerCounts <= checkingCounts)
        {
            Destroy(gameObject);
        }
    }
}
