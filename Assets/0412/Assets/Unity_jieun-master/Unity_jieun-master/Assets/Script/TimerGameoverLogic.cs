using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerGameoverLogic : MonoBehaviour {

    int countDownStartValue = 5;
    public Text timerUI;

    // Use this for initialization
    void Start () {
        countDownTimer();
        

    }
	void countDownTimer()
    {
        if(countDownStartValue > 0)
        {
            timerUI.text = "Timer : " + countDownStartValue;
            countDownStartValue--;
            Invoke("countDownTimer", 1.0f);
        }
        else
        {
            timerUI.text = "GameOver!!";
           
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
