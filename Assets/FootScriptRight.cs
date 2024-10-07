using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FootScriptRight : MonoBehaviour
{

    float timecount = 0;
    public GameObject pos1;
    public GameObject pos2;
    GameObject target;
    public string status = "XD";
    // Update is called once per frame
    void Update()
    {
        if (GameStates.instance.CurrentGameStates == "PLAYING")
        {
            if (status == "PUNCHING")
            {
                gameObject.GetComponent<Animator>().applyRootMotion = false;
            }
            else
            {
                if (target == null)
                {
                    target = pos1;
                }
                if (target == pos1)
                {
                    transform.position = Vector3.MoveTowards(transform.position, pos1.transform.position, Time.deltaTime * 8);
                    if (transform.position == pos1.transform.position)
                    {
                        target = pos2;
                    }
                }
                if (target == pos2)
                {
                    transform.position = Vector3.MoveTowards(transform.position, pos2.transform.position, Time.deltaTime * 8);
                    if (transform.position == pos1.transform.position)
                    {
                        target = pos1;
                    }
                }

                timecount += Time.deltaTime;
                if (timecount > 10)
                {
                    gameObject.GetComponent<Animator>().SetTrigger("attack");
                    timecount = 0;
                }
            }
        }
    }
}
