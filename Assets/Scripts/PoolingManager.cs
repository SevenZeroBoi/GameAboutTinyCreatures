using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    public static PoolingManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("tak 1 souy p syou");
        }
        instance = this;
    }

    private Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();

    public GameObject GetFromPool(string poolKey, GameObject prefab, Vector3 position, Quaternion rotation)
    {
        if (poolDictionary.ContainsKey(poolKey) && poolDictionary[poolKey].Count > 0)
        {
            GameObject objectToReuse = poolDictionary[poolKey].Dequeue();
            objectToReuse.SetActive(true);
            objectToReuse.transform.position = position;
            objectToReuse.transform.rotation = rotation;
            return objectToReuse;
        }
        else
        {
            GameObject newObject = Instantiate(prefab, position, rotation);
            return newObject;
        }
    }

    public void ReturnToPool(string poolKey, GameObject objectToReturn)
    {
        if (!poolDictionary.ContainsKey(poolKey))
        {
            poolDictionary[poolKey] = new Queue<GameObject>();
        }

        objectToReturn.SetActive(false);
        poolDictionary[poolKey].Enqueue(objectToReturn);
    }
}