using Unity.VisualScripting;
using UnityEngine;

public class MovingCreatures : MonoBehaviour
{
    public static MovingCreatures instance;

    private void Awake()
    {
        instance = this;
    }

    float moveSpeed = 4;
    [HideInInspector] public Vector3 rotation = Vector3.down;
    void Update()
    {
        transform.position += rotation * moveSpeed * Time.deltaTime;
        RangeBetweenNextFollower();
    }
    
    float rangebetween = 0;
    float rangeBetweenCreature = 8;
    void RangeBetweenNextFollower()
    {
        if (GameStates.instance.creatureStorage.IndexOf(gameObject) == 1)
        {
            GameObject Object = GameStates.instance.creatureStorage[GameStates.instance.creatureStorage.IndexOf(gameObject) - 1];
            rangebetween = Mathf.Abs(transform.position.x - Object.transform.position.x) + Mathf.Abs(transform.position.y - Object.transform.position.y);
            if (rangebetween < rangeBetweenCreature)
            {
                if (rotation == Vector3.up || rotation == Vector3.down)
                {
                    transform.position += (rotation *-1* (rangebetween - Mathf.Abs(Object.transform.position.x - gameObject.transform.position.x)))*Time.deltaTime;
                }
                else if (rotation == Vector3.right || rotation == Vector3.left)
                {
                    transform.position += (rotation * -1 * (rangebetween - Mathf.Abs(Object.transform.position.y - gameObject.transform.position.y))) * Time.deltaTime;
                }
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TURNRIGHT")
        {
            transform.position = collision.transform.position;
            rotation = Vector3.right;
            GameStates.instance.rotationObjectStorage[collision.gameObject]--;

        }
        if (collision.gameObject.tag == "TURNLEFT")
        {
            transform.position = collision.transform.position;
            rotation = Vector3.left;
            GameStates.instance.rotationObjectStorage[collision.gameObject]--;

        }
        if (collision.gameObject.tag == "TURNUP")
        {
            transform.position = collision.transform.position;
            rotation = Vector3.up;
            GameStates.instance.rotationObjectStorage[collision.gameObject]--;

        }
        if (collision.gameObject.tag == "TURNDOWN")
        {
            transform.position = collision.transform.position;
            rotation = Vector3.down;
            GameStates.instance.rotationObjectStorage[collision.gameObject]--;

        }
    }
}
