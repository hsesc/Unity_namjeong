using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxKey : MonoBehaviour {

  //  public bool inTrigger;

    private void Update()
    {

            if (Input.GetKeyDown(KeyCode.T))
            {
               
                Destroy(this.gameObject);
            }
        }
    

}
