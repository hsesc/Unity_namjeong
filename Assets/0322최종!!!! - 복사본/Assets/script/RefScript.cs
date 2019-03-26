using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefScript : MonoBehaviour {

    Animator anim2;

	// Use this for initialization
	void Start () {
        anim2 = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            anim2.Play("refopen2", -1, 0);
            anim2.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            anim2.Play("refclose2", -1, 0);
            anim2.enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //anim2.SetTrigger("OpenRef");
    }

    private void OnTriggerExit(Collider other)
    {
      // anim2.enabled = true;
    }

    void pauseAnimationEvent()
    {
        anim2.enabled = false;
    }
}
