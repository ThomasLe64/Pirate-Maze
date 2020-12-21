using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    Image img;
    public float timeAmt;
    public float time;
    public Text timeText;
    public GameObject obj;
    public int currLevel = 1;
    public int oldcurrLevel = 0;
    public float currTime;

    // Start is called before the first frame update
    void Start()
    {
        img = this.GetComponent<Image>();
        time = timeAmt;
        currTime = time;
    }

    // Update is called once per frame
    void Update()
    {
        oldcurrLevel = currLevel;
        currLevel = currLevel = obj.GetComponent<MazeGenerator>().currentLevel;
        if (time > 0)
        {
            time -= Time.deltaTime;
            img.fillAmount = time / timeAmt;
            timeText.text = time.ToString("00");
        }
        if(oldcurrLevel != currLevel)
        {
            int temp = (currLevel / 5) + 1;
            int temp2 = temp * 15;
            time = currTime + temp2;
            timeAmt = time;
            currTime = time;
        }
        if(time < 0 && oldcurrLevel == currLevel)
        {
            SceneManager.LoadScene(4);
        }
    }
}
