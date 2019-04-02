using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDrawer : MonoBehaviour {

    Animator anim;
    bool IsClose; //냉장고Collider 판단 
    bool open = false; //refDoor 상태 판단

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (IsClose == true)
            {
                if (open == false)
                {
                    // anim.SetTrigger("OpenDoor");
                    anim.Play("OpenRightDrawer", -1, 0);
                    anim.enabled = true;
                    open = true;
                }
                else if (open == true)
                {
                    anim.Play("CloseRightDrawer", -1, 0);
                    anim.enabled = true;
                    open = false;
                }
            }

        }

    }

    private void OnTriggerEnter(Collider other) //냉장고 영역안으로 
    {
        IsClose = true;
        //   isDoor2 = true;
    }

    private void OnTriggerExit(Collider other) //냉장고 영역밖으로 
    {
        IsClose = false;
        //    isDoor2 = false;
        //anim.enabled = true;   
    }

    void pauseAnimationEvent()
    {
        anim.enabled = false;
    }
}
