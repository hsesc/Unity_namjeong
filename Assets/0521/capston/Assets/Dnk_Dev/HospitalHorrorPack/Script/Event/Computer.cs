using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Computer : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change()
    {
        GetComponent<MeshRenderer>().material = Resources.Load("Icons/bana") as Material;

    }
}
