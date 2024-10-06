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
        PositionToFollow();
    }

    public GameObject followingPosition;
    void PositionToFollow()
    {
        if (followersStorage.Count == 0)
        {
            followingPosition.transform.position = MainCharacter.instance.transform.position + (-1 * rangeBetweenFollowers * MainCharacter.instance.rotationPos);
        }
        else
        {
            //followingPosition.transform.position = Ga+ (-1 * rangeBetweenFollowers * MainCharacter.instance.rotationPos);
        }
    }

    

    
}
