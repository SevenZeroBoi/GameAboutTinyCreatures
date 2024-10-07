using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using static UnityEditor.PlayerSettings;

public class MainCharacter : MonoBehaviour
{
    public static MainCharacter instance;
    [HideInInspector] public GameObject objectFollower;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rotationPos = Vector3.zero;
        objectFollower = Instantiate(GameStates.instance.objectFollowerPrefab);
        GameStates.instance.allFollowingDetection.Add(objectFollower);
        objectFollower.transform.position = transform.position + (-1 * GameStates.instance.rangeBetweenFollowers * rotationPos);
    }
    float animtimecheck = 0;
    int rotation = -1;
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (GameStates.instance.CurrentGameStates != "GAMEOVER")
        {
            Movement();
        }
        

        animtimecheck += Time.deltaTime;
        if (animtimecheck > 2)
        {
            transform.rotation = Quaternion.Euler(0, 0, 20 * rotation);
            rotation *= -1;
            animtimecheck = 0;
        }
    }


    public Vector3 rotationPos = Vector3.zero;
    void Movement() //main movement
    {
        transform.position += rotationPos * GameStates.instance.movementSpeed * Time.deltaTime;
        objectFollower.transform.position = transform.position + (-1 * GameStates.instance.rangeBetweenFollowers * rotationPos);
        if (rotationPos != Vector3.left && rotationPos != Vector3.right)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                rotationPos = Vector3.right;
                CreateRotationPos(rotationPos); if (GameStates.instance.CurrentGameStates == "MENU") GameStates.instance.CurrentGameStates = "PLAYING";

            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                rotationPos = Vector3.left;
                CreateRotationPos(rotationPos);
                if (GameStates.instance.CurrentGameStates == "MENU") GameStates.instance.CurrentGameStates = "PLAYING";
            }
        }
        if (rotationPos != Vector3.up && rotationPos != Vector3.down)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rotationPos = Vector3.up;
                CreateRotationPos(rotationPos); if (GameStates.instance.CurrentGameStates == "MENU") GameStates.instance.CurrentGameStates = "PLAYING";
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                rotationPos = Vector3.down;
                CreateRotationPos(rotationPos); if (GameStates.instance.CurrentGameStates == "MENU") GameStates.instance.CurrentGameStates = "PLAYING";
            }
        }
        /*
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GameStates.instance.movementSpeed *= 1.5f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            GameStates.instance.movementSpeed = GameStates.instance.normalSpeed;
        }*/
    }

    public GameObject emptyPos;
    void CreateRotationPos(Vector3 pos) //send rotation pos when that location
    {
        if (GameStates.instance.allFollowersStorage.Count != 0)
        {
            GameObject newemptyPos = Instantiate(emptyPos, transform.position, Quaternion.identity);
            if (pos == Vector3.right)
            {
                newemptyPos.tag = "RIGHT";
            }
            else if (pos == Vector3.left)
            {
                newemptyPos.tag = "LEFT";
            }
            else if (pos == Vector3.up)
            {
                newemptyPos.tag = "UP";
            }
            else if (pos == Vector3.down)
            {
                newemptyPos.tag = "DOWN";
            }
            GameStates.instance.AddEveryFollowerTarget(newemptyPos);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "CREATURES" || other.gameObject.tag=="SETNEWONE")
        {
            GameLose();
        }
    }

    public void GameLose()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, GameStates.instance.deathLocation.transform.position, Time.deltaTime * 17);
        GameStates.instance.CurrentGameStates = "GAMEOVER";
        GetComponent<AudioSource>().PlayOneShot(lose);
        song.SetActive(false);
    }
    
    public AudioClip lose;
    public GameObject song;
    
}