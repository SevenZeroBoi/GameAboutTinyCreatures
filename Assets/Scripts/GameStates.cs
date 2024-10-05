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
        RotationPointChecking();
    }

    [Header("Creatures Storage")]
    public List<GameObject> creatureStorage = new List<GameObject>();

    [Header("RotationStorage")]
    public Dictionary<Vector3, Vector2> rotationPoint = new Dictionary<Vector3, Vector2>();

    void RotationPointChecking()
    {
        foreach (GameObject creature in creatureStorage)
        {
            var movingCreature = creature.GetComponent<MovingCreatures>();
            foreach (var pos in rotationPoint)
            {
                if (Vector3.Distance(creature.transform.position, pos.Key) <= 0.1f)
                {
                    movingCreature.rotation = pos.Value;
                    movingCreature.transform.position = creature.transform.position;
                    break;
                }
            }
        }
    }
}
