using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
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
    public List<GameObject> allFollowingDetection;

    [Header("Movements and range")]
    public float movementSpeed;
    public float rangeBetweenFollowers;
    public GameObject objectFollowerPrefab;
    public void AddEveryFollowerTarget(GameObject targetlocation) //set location to rotate for every obje
    {
        foreach (GameObject follower in allFollowersStorage)
        {
            follower.GetComponent<FollowerScript>().subTargetList.Add(targetlocation);
        }
    }

    
    public void CreaturesDeath(GameObject start)
    {
        for (int i = allFollowersStorage.IndexOf(start); i < allFollowersStorage.Count; i++)
        {
            Animator anim = start.GetComponent<Animator>();
            anim.SetTrigger("Death");
            Destroy(allFollowersStorage[i]);
            Destroy(allFollowingDetection[i]);
        }
        allFollowingDetection[allFollowersStorage.IndexOf(start)].GetComponent<CircleCollider2D>().enabled = true;
    }


    [Header("Score System")]
    public int OverallScore = 0;
    public float OverallScoreMultiply = 1;
    public int CreaturesScoreMultiply = 1;
    public int CreaturesSpeedBoost = 1;
    public int CreaturesDividingScore = 0;
    public int CreaturesSpeedSlowing = 0;

    public int CreaturesInHouseCount = 0;
    float timecount = 0;

    void ScoreByTime()
    {
        timecount += Time.deltaTime;
        if (timecount > 2)
        {
            OverallScore += (int)Mathf.Round(CreaturesInHouseCount * 500 * OverallScoreMultiply);
            OverallScore += (int)Mathf.Round(200 * OverallScoreMultiply);
            timecount = 0;
        }
    }
    void PickUpCreatures()
    {
        OverallScore += 500;
    }



}
