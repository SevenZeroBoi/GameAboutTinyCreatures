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
    
}
