using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotateCheckDelete : MonoBehaviour
{
    public int checkingcount = 0;
    private void Start()
    {
        checkingcount = GameStates.instance.allFollowersStorage.Count;
    }

    private void Update()
    {
        if (checkingcount == 0)
        {
            gameObject.SetActive(false);
        }
    }
}