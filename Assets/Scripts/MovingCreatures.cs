using UnityEngine;

public class MovingCreatures : MonoBehaviour
{
    public float moveSpeed;
    [HideInInspector] public Vector3 rotation = Vector3.down;
    public int changetrigger = 0;
    void Update()
    {
        transform.position += rotation * moveSpeed * Time.deltaTime;
    }
}
