using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeAddDisplay : MonoBehaviour
{

    public Text time;
    public GameObject innerCircle;

    // Start is called before the first frame update
    void Start()
    {
        time.text = PlayerPrefs.GetInt("time").ToString();
    }

    void Update()
    {
        time.text = " " +  PlayerPrefs.GetInt("time").ToString();
       
    }

    //adds 15 seconds to the time
    public void timeClick()
    {
        if(PlayerPrefs.GetInt("time") > 0)
        {
            innerCircle = GameObject.FindWithTag("inner");
            innerCircle.GetComponent<Timer>().time = innerCircle.GetComponent<Timer>().time + 15;
            innerCircle.GetComponent<Timer>().timeAmt = innerCircle.GetComponent<Timer>().timeAmt + 15;
            PlayerPrefs.SetInt("time", PlayerPrefs.GetInt("time") - 1);

        }
    }
}
