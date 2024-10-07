using UnityEngine;

public class CameraSetup : MonoBehaviour
{
    void Start()
    {
        Camera.main.orthographic = true;
        Camera.main.orthographicSize = 700;
    }

    
}
