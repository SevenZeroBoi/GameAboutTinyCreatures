using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameStates : MonoBehaviour
{

    public static GameStates instance;
    private void Awake()
    {
        instance = this;
    }
    [Header("Follower Storage")]
    public List<GameObject> allFollowersStorage;

    [Header("Movements and range")]
    public float movementSpeed;
    public float rangeBetweenFollowers;
    public void AddEveryFollowerTarget(GameObject targetlocation) //set location to rotate for every obje
    {
        foreach (GameObject follower in allFollowersStorage)
        {
            follower.GetComponent<FollowerScript>().subTargetList.Add(targetlocation);
        }
    }

    [Header("Score System")]
    public int OverallScore = 0;
    public float OverallScoreMultiply = 1;
}
