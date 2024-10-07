using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawnningscirptpt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject pos1;
    public GameObject pos2;
    public GameObject[] posiblepos1;
    public GameObject[] posiblepos2;
    float timecount = 0;

    // Update is called once per frame
    void Update()
    {
        if (GameStates.instance.CurrentGameStates == "PLAYING")
        {
            timecount += Time.deltaTime;
            if (timecount > 9 / GameStates.instance.everytingmultiply)
            {
                int Randoma = Random.Range(0, 2);
                if (Randoma == 0)
                {
                    Instantiate(posiblepos1[Random.Range(0, posiblepos1.Length)],transform.position,Quaternion.identity);
                }
                else
                {
                    Instantiate(posiblepos2[Random.Range(0, posiblepos2.Length)], transform.position, Quaternion.identity);

                }
                timecount = 0;
            }
        }
    }
}
