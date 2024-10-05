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

    private void Update()
    {
        DeletingRotation();
    }

    [Header("Creatures Storage")]
    public List<GameObject> creatureStorage = new List<GameObject>();


    #region Rotating
    [Header("RotationStorage")]
    public Dictionary<GameObject, int> rotationObjectStorage = new Dictionary<GameObject, int>();
    public GameObject objectToRotate;

    
    void DeletingRotation()
    {
        List<GameObject> keysToDelete = new List<GameObject>();

        foreach (var a in rotationObjectStorage)
        {
            if (a.Value == 0)
            {
                Destroy(a.Key);
                keysToDelete.Add(a.Key);
            }
        }

        foreach (var key in keysToDelete)
        {
            rotationObjectStorage.Remove(key);
        }

    }
    #endregion


    #region Scoring System
    public float GameScore = 0;
    public float ScoreMultiplier = 1;
    void AddingTimeScore()
    {
        GameScore += Time.deltaTime * ScoreMultiplier;
    }

    void AddingScore(float score)
    {
        GameScore += score * ScoreMultiplier;
    }


    int countofBadCreature = 0;
    void ScoreMultiplyDebuff()
    {
        ScoreMultiplier /= countofBadCreature;
    }

    void ChangeScoreMultiplier(string addorminus, float number)
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
}

