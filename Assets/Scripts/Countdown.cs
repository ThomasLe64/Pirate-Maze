using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public float countdownTime;
    public Text countdownDisplay;
    public GameObject obj;
    public GameObject pauseUI;
    public int currLevel = 1;
    public int oldcurrLevel = 0;

    void Start()
    {
        //StartCoroutine(countdown());
    }
    void Update()
    {
        oldcurrLevel = currLevel;
        currLevel = obj.GetComponent<MazeGenerator>().currentLevel;
       
            //countdownDisplay.gameObject.SetActive(true);
            if (countdownTime > 0)
            {
                countdownTime -= Time.unscaledDeltaTime;
                countdownDisplay.text = countdownTime.ToString("0");
                Time.timeScale = 0.0f;
            }
            else
            {
                countdownDisplay.text = "GO!";
                countdownDisplay.text = "";
                Time.timeScale = 1f;
                //countdownDisplay.gameObject.SetActive(false);
            }
            if(pauseUI.activeSelf == true)
            {
                 Time.timeScale = 0f;
             }
            if(oldcurrLevel != currLevel)
            {
                countdownTime = 5f;
            }
            
            //Debug.Log("TEMP = " + temp);
            //Debug.Log("CURRLEVEL = " + currLevel);       
    }

    /*
    IEnumerator countdown()
    {
        Time.timeScale = 0.0f;
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        countdownDisplay.text = "GO!";
        Time.timeScale = 1f;
        //GameController.instance.BeginGame();
        yield return new WaitForSeconds(1f);
        countdownDisplay.gameObject.SetActive(false);
    }
    */
}
