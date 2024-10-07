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
    private void Start()
    {
        movementSpeed = normalSpeed;
    }
    [Header("Follower Storage")]
    public List<GameObject> allFollowersStorage;
    public List<GameObject> allFollowingDetection;

    [Header("Movements and range")]
    public float normalSpeed;
    [HideInInspector] public float movementSpeed;
    public float rangeBetweenFollowers;
    public GameObject objectFollowerPrefab;
    public void AddEveryFollowerTarget(GameObject targetlocation) //set location to rotate for every obje
    {
        if (allFollowersStorage != null)
        {
            foreach (GameObject follower in allFollowersStorage)
            {
                follower.GetComponent<FollowerScript>().subTargetList.Add(targetlocation);
            }
        }
    }


    public void CreaturesDeath(GameObject start)
    {
        int startIndex = allFollowersStorage.IndexOf(start);

        if (startIndex >= 0)
        {
            for (int i = allFollowersStorage.Count - 1; i >= startIndex; i--)
            {
                if (allFollowersStorage[i].name == "RUNNER")
                {
                    GameStates.instance.normalSpeed *= 0.2f;
                }
                else if (allFollowersStorage[i].name == "ROCK")
                {
                    GameStates.instance.normalSpeed /= 0.2f;
                }
                else if (allFollowersStorage[i].name == "ROCKET")
                {
                    GameStates.instance.OverallScoreMultiply += 0.2f;
                }
                else if (allFollowersStorage[i].name == "STAR")
                {
                    GameStates.instance.OverallScoreMultiply += 1;
                }
                Animator anim = allFollowersStorage[i].GetComponent<Animator>();
                anim.SetTrigger("Death");
            }

            for (int i = allFollowingDetection.Count - 1; i > startIndex; i--)
            {
                PoolingManager.instance.ReturnToPool(allFollowingDetection[i].name, allFollowingDetection[i]);
                allFollowingDetection.RemoveAt(i);
            }

            if (startIndex < allFollowingDetection.Count)
            {
                allFollowingDetection[startIndex].GetComponent<CircleCollider2D>().enabled = true;
                allFollowingDetection[startIndex].GetComponent<Animator>().enabled = true;
            }
        }
    }

    [Header("Score System")]
    public int OverallScore = 0;
    public float OverallScoreMultiply = 1;

    public int normalCount = 0;
    public int nerdCount = 0;
    public int heartCount = 0;
    public int flowerCount = 0;
    public int bugCount = 0;
    public int cloudCount = 0;

    public int CreaturesInHouseCount = 0;
    float timecount = 0;

    void ScoreByTime()
    {
        timecount += Time.deltaTime;
        if (timecount > 2)
        {
            OverallScore += Mathf.RoundToInt(((normalCount * 50) + (nerdCount * 100) + (heartCount * 300) + (800 * flowerCount)
                - (bugCount * 200) - (cloudCount * 500))*OverallScoreMultiply);
        }
    }
    


}
