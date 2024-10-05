using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controlling : MonoBehaviour
{
    private void Update()
    {
        RotationCooldown();
    }

    float cooldownrotate = 0;
    void RotationCooldown()
    {
        cooldownrotate += Time.deltaTime;
        if (cooldownrotate > 0.4)
        {
            Rotation();
        }
    }
    void Rotation()
    {
        if (Input.GetKeyDown(KeyCode.D) && MovingCreatures.instance.rotation != Vector3.right)
        {
            GameObject newobj = (Instantiate(GameStates.instance.objectToRotate,transform.position,Quaternion.identity));
            newobj.tag = "TURNRIGHT";
            GameStates.instance.rotationObjectStorage.Add(newobj, GameStates.instance.creatureStorage.Count);
            cooldownrotate = 0;
        }
        else if (Input.GetKeyDown(KeyCode.A) && MovingCreatures.instance.rotation != Vector3.left)
        {
            GameObject newobj = (Instantiate(GameStates.instance.objectToRotate, transform.position, Quaternion.identity));
            newobj.tag = "TURNLEFT";
            GameStates.instance.rotationObjectStorage.Add(newobj, GameStates.instance.creatureStorage.Count);
            cooldownrotate = 0;
        }
        else if (Input.GetKeyDown(KeyCode.S) && MovingCreatures.instance.rotation != Vector3.down)
        {
            GameObject newobj = (Instantiate(GameStates.instance.objectToRotate, transform.position, Quaternion.identity));
            newobj.tag = "TURNDOWN";
            GameStates.instance.rotationObjectStorage.Add(newobj, GameStates.instance.creatureStorage.Count);
            cooldownrotate = 0;
        }
        else if (Input.GetKeyDown(KeyCode.W) && MovingCreatures.instance.rotation != Vector3.up)
        {
            GameObject newobj = (Instantiate(GameStates.instance.objectToRotate, transform.position, Quaternion.identity));
            newobj.tag = "TURNUP";
            GameStates.instance.rotationObjectStorage.Add(newobj, GameStates.instance.creatureStorage.Count);
            cooldownrotate = 0;
        }
    }
}
