using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCounter : MonoBehaviour
{
    //Image img;
    public int currLevel = 1;
    public Text timeText;
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        //img = this.GetComponent<Image>();
        //currLevel = player.GetComponent<ChestCollision>().levelCounter;
    }

    // Update is called once per frame
    void Update()
    {
        currLevel = obj.GetComponent<MazeGenerator>().currentLevel;
        timeText.text = "Level: " + currLevel.ToString("00");
    }
}
