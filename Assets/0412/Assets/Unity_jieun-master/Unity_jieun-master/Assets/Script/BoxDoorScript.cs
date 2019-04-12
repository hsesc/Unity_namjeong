using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDoorScript : MonoBehaviour {

    public static bool doorKey;
    public bool open;
    public bool close;
    public bool inTrigger;

    void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
    }
    void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }
    void Update()
    {
        if (inTrigger)
        {
                if (close)
                {
                    if (doorKey)
                    {
                        if (Input.GetKeyDown(KeyCode.T))
                        {
                            open = true;
                            close = false;

                        }
                    }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.T))
                    {
                        close = true;
                        open = false;
                    }
                }
            
        }
        if (open)
        {
            var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, -90.0f, 0.0f), Time.deltaTime * 200);
            transform.rotation = newRot;
        }
        else
        {
            var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 0.0f, 0.0f), Time.deltaTime * 200);
            transform.rotation = newRot;
        }
    }

    private void OnGUI()
    {
        if (inTrigger)
        {
            if (open)
            {
               
                GUI.Box(new Rect(0, 0, 200, 25), "Press T to close");
            }
            else
            {
                if (doorKey)
                {
                    GUI.Box(new Rect(0, 0, 300, 25), "Press T to open");
                    
                }
                else
                {
                    GUI.Box(new Rect(0, 0, 200, 25), "Need a Key!");
                }
            }
        }
    }
}
