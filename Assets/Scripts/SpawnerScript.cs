using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    float timecheck1 = 0;
    float timecheck2 = 4;
    public GameObject[] spawningRate1;
    public GameObject[] spawningRate2;
    public GameObject[] spawningRate3;
    public void Update()
    {
        if (GameStates.instance.CurrentGameStates == "PLAYING")
        {
            timecheck1 += Time.deltaTime;
            if (timecheck1 > timecheck2/ GameStates.instance.everytingmultiply)
            {
                int RandomA = Random.Range(0, 10);
                if (RandomA < 6)
                {
                    int RandomB = Random.Range(0, spawningRate1.Length);
                    Instantiate(spawningRate1[RandomB], transform.position, Quaternion.identity).name = spawningRate1[RandomB].name;
                }
                else if (RandomA < 9)
                {
                    int RandomB = Random.Range(0, spawningRate2.Length);
                    Instantiate(spawningRate2[RandomB], transform.position, Quaternion.identity).name = spawningRate2[RandomB].name;
                }
                else
                {
                    int RandomB = Random.Range(0, spawningRate3.Length);
                    Instantiate(spawningRate3[RandomB], transform.position, Quaternion.identity).name = spawningRate3[RandomB].name;
                }
                timecheck1 = 0;
            }
        }

    }
}