using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bookcase : MonoBehaviour
{
    private Vector3 initPos;    //원래 위치

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindWithTag("BookCube").GetComponent<GetCube>().get == true)
        {
            Invoke("move", 10f);
        }
    }

    void move()
    {
        var newPos = Vector3.MoveTowards
         (transform.position, new Vector3(initPos.x, initPos.y, initPos.z + 1.0f), 0.005f);
        transform.position = newPos; //원래 위치에서 z 방향으로 약간 이동
    }
    
 
}
