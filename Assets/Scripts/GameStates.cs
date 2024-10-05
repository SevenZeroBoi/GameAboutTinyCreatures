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
    }

    [Header("Creatures Storage")]
    public List<GameObject> creatureStorage = new List<GameObject>();

    [Header("RotationStorage")]
    public Dictionary<GameObject, int> rotationObjectStorage = new Dictionary<GameObject, int>();
    public GameObject objectToRotate;
    
    
}
