using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEditor.Rendering;
using UnityEngine;

public class GameStates : MonoBehaviour
{

    public static GameStates instance;


    public string CurrentGameStates = "MENU";


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

    public GameObject deathLocation;
    public void CreaturesDeath(GameObject start)
    {
        int startIndex = allFollowersStorage.IndexOf(start);

        if (startIndex >= 0)
        {
            for (int i = allFollowersStorage.Count - 1; i >= startIndex; i--)
            {
                allFollowersStorage[i].GetComponent<CircleCollider2D>().enabled = false;
                allFollowersStorage[i].GetComponent<FollowerScript>().stage = "DEATH";
                if (allFollowersStorage[i].name == "RUNNER")
                {
                    GameStates.instance.normalSpeed /= 0.2f;
                }
                else if (allFollowersStorage[i].name == "ROCK")
                {
                    GameStates.instance.normalSpeed *= 0.2f;
                }
                else if (allFollowersStorage[i].name == "ROCKET")
                {
                    GameStates.instance.OverallScoreMultiply -= 0.2f;
                }
                else if (allFollowersStorage[i].name == "STAR")
                {
                    GameStates.instance.OverallScoreMultiply -= 1;
                }
                else if (allFollowersStorage[i].name == "NORMAL")
                {
                    GameStates.instance.normalCount--;
                }
                else if (allFollowersStorage[i].name == "NERD")
                {
                    GameStates.instance.nerdCount--;
                }
                else if (allFollowersStorage[i].name == "HEART")
                {
                    GameStates.instance.heartCount--;
                }
                else if (allFollowersStorage[i].name == "FLOWER")
                {
                    GameStates.instance.flowerCount--;
                }
                else if (allFollowersStorage[i].name == "BUG")
                {
                    GameStates.instance.bugCount--;
                }
                else if (allFollowersStorage[i].name == "CLOUD")
                {
                    GameStates.instance.cloudCount--;
                }
                else if (allFollowersStorage[i].name == "FIRE")
                {
                    GameStates.instance.fireCount--;
                }
                allFollowersStorage.RemoveAt(i);

            }

            for (int i = allFollowingDetection.Count - 1; i > startIndex; i--)
            {
                Destroy(allFollowingDetection[i]);
                allFollowingDetection.RemoveAt(i);
            }

            if (startIndex < allFollowingDetection.Count)
            {
                allFollowingDetection[startIndex].GetComponent<CircleCollider2D>().enabled = true;
                allFollowingDetection[startIndex].GetComponent<SpriteRenderer>().enabled = true;

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
    public int fireCount = 0;

    float timecount = 0;


    float gametime = 0;
    public float everytingmultiply = 1;
    void ScoreByTime()
    {
        if (OverallScore < 0)
        {
            OverallScore = 0;
        }
        timecount += Time.deltaTime;
        if (timecount > 2)
        {
            OverallScore += Mathf.RoundToInt(((normalCount * 200) + (nerdCount * 400) + (heartCount * 700) + (1100 * flowerCount)
                - (bugCount * 200) - (cloudCount * 300) /*- (fireCount *700))*/ * OverallScoreMultiply));

            timecount = 0;
        }
    }
    public TMP_Text textscore1;
    public TMP_Text textscore2;
    public GameObject presstoStart;
    private void Update()
    {
        textscore1.text = OverallScore.ToString("D8");
        textscore2.text = OverallScore.ToString("D8");
        if (CurrentGameStates != "MENU")
        {
            presstoStart.SetActive(false);
        }
        if (CurrentGameStates == "PLAYING")
        {
            ScoreByTime();
            gametime += Time.deltaTime;
            if (gametime > 60)
            {
                everytingmultiply += 0.2f;
                gametime = 0;
                normalSpeed += 0.1f;
            }
            if (fireCount > 0)
            {
                firecounttimecheck += Time.deltaTime;
                if (firecounttimecheck > 10)
                {
                    MainCharacter.instance.GameLose();

                    CreaturesDeath(allFollowersStorage[0]);
                }
                fireobj.SetActive(true);
            }
            else
            {
                firecounttimecheck = 0;
                fireobj.SetActive(false);
            }
        }
        if (CurrentGameStates == "GAMEOVER")
        {
            scorefinal.text = "SCORE: " + OverallScore.ToString();
            loseStage.SetActive(true);
            textscore2.color = new Color(0, 0, 0, 0);
            textscore2.color = new Color(0, 0, 0, 0);
        }


        
        
        
    }
    float firecounttimecheck = 0;

    public GameObject fireobj;
    public GameObject loseStage;
    public TMP_Text scorefinal;
}