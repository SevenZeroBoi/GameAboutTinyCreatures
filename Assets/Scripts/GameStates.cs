using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameStates : MonoBehaviour
{
    public static GameStates instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    #region Scoring System
    public float GameScore = 0;
    public float ScoreMultiplier = 1;
    void AddingTimeScore()
    {
        GameScore += Time.deltaTime* ScoreMultiplier;
    }

    void AddingScore(float score)
    {
        GameScore += score * ScoreMultiplier;
    }


    int countofBadCreature = 0;
    void ScoreMultiplyDebuff()
    {
        ScoreMultiplier/=countofBadCreature;
    }

    void ChangeScoreMultiplier(string addorminus,float number)
    {
        if (addorminus == "ADD")
        {
            ScoreMultiplier += number;
        }
        else if (addorminus == "MINUS")
        {
             ScoreMultiplier -= number;
        }
    }

    void GetHit()
    {
        GameScore -= 5000;
    }

    void PhaseChange()
    {

    }
    #endregion


    #region Follower Controlling
    [Header("Follower Controlling")]
    public List<GameObject> followersStorage = new List<GameObject>();
    Animator anim;
    public void NewFollowers(GameObject newFollower)
    {
        anim = newFollower.GetComponent<Animator>();
        anim.SetTrigger("happy");
        followersStorage.Add(newFollower);
    }
    public void FollowersGotCut(GameObject nearest)
    {
        int nearestIndex = followersStorage.IndexOf(nearest);
        if (nearestIndex != -1)
        {
            followersStorage.RemoveRange(nearestIndex, followersStorage.Count - nearestIndex);
        }
        for (int i = nearestIndex; i < followersStorage.Count; i++)
        {
            anim = followersStorage[nearestIndex].GetComponent<Animator>();
            anim.SetTrigger("death");
        }
    }

    #endregion

    public static GameObject[] placeableObject; //house,flower,trap


    //Game Event list - Spawn Creatures / Cat / Bird / Ant / Bird / Frog / Item Box with Creature
    //Placeable Item - House / Flower / Trap

}
