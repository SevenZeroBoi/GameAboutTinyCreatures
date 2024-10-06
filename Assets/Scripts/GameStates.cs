using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameStates : MonoBehaviour
{
    
    public static GameStates instance;

    public List<GameObject> followersStorage;

    public List<GameObject> moveTowardsCheckStorage;
    public float rangeBetweenFollowers;


    private void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        
    }

    public GameObject followingPosition;




}
