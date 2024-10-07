using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    float timecheck1 = 0;
    float timecheck2 = 4;
    GameObject[] spawningRate1;
    GameObject[] spawningRate2;
    GameObject[] spawningRate3;
    public void Update()
    {
        timecheck1 += Time.deltaTime;
        if (timecheck1 < timecheck2)
        {
            int RandomA = Random.Range(0, 10);
            if (RandomA < 6)
            {
                GameObject newemptyPos = PoolingManager.instance.GetFromPool(spawningRate1[Random.Range(0, spawningRate1.Length)].name, spawningRate1[Random.Range(0, spawningRate1.Length)], transform.position, Quaternion.identity);
            }
            else if (RandomA < 9)
            {
                GameObject newemptyPos = PoolingManager.instance.GetFromPool(spawningRate2[Random.Range(0, spawningRate1.Length)].name, spawningRate1[Random.Range(0, spawningRate1.Length)], transform.position, Quaternion.identity);
            }
            else 
            {
                GameObject newemptyPos = PoolingManager.instance.GetFromPool(spawningRate3[Random.Range(0, spawningRate1.Length)].name, spawningRate1[Random.Range(0, spawningRate1.Length)], transform.position, Quaternion.identity);
            }
            timecheck1 = 0;
        }
        
    }
}
