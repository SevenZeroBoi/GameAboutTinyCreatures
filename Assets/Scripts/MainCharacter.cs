using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MainCharacter : MonoBehaviour
{
    
    public static MainCharacter instance;

    public float movementSpeed;
    [HideInInspector] public Vector3 rotationPos = Vector3.zero;


    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (lol == 0)
        {
            StartingGame();
        }
        Movement();
        PositionToFollow();
    }
    int lol = 0;
    void StartingGame()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            rotationPos = Vector3.down;
            lol = 1;
        }
    }
    void Movement()
    {
        transform.position += Time.deltaTime*rotationPos*movementSpeed;
        if (rotationPos != Vector3.left && rotationPos != Vector3.right)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                rotationPos = Vector3.right;
                
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                rotationPos = Vector3.left;
            }
        }
        if (rotationPos != Vector3.up && rotationPos != Vector3.down)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rotationPos = Vector3.up;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                rotationPos = Vector3.down;
            }
        }

    }
    public GameObject newfollowingPosition;
    private void Start()
    {
        newfollowingPosition = Instantiate(GameStates.instance.followingPosition, transform.position + (Vector3.zero * GameStates.instance.rangeBetweenFollowers), Quaternion.identity);
    }
    void PositionToFollow()
    {
        newfollowingPosition.transform.position = transform.position + (-1 * GameStates.instance.rangeBetweenFollowers * rotationPos);
    }

    void UsingItem()
    {
        
    }


}
