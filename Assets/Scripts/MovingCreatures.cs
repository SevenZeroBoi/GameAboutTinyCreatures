using UnityEngine;

public class MovingCreatures : MonoBehaviour
{
    float moveSpeed = 4;
    [HideInInspector] public Vector3 rotation = Vector3.down;
    void Update()
    {
        transform.position += rotation * moveSpeed * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TURNRIGHT")
        {
            transform.position = collision.transform.position;
            rotation = Vector3.right;
            //GameStates.instance.rotationObjectStorage[collision.gameObject]--;

        }
        if (collision.gameObject.tag == "TURNLEFT")
        {
            transform.position = collision.transform.position;
            rotation = Vector3.left;
            //GameStates.instance.rotationObjectStorage[collision.gameObject]--;

        }
        if (collision.gameObject.tag == "TURNUP")
        {
            transform.position = collision.transform.position;
            rotation = Vector3.up;
            //GameStates.instance.rotationObjectStorage[collision.gameObject]--;

        }
        if (collision.gameObject.tag == "TURNDOWN")
        {
            transform.position = collision.transform.position;
            rotation = Vector3.down;
            //GameStates.instance.rotationObjectStorage[collision.gameObject]--;

        }
    }
}
