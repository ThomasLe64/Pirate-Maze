using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCollision : MonoBehaviour
{

    public GameObject mz;
    public GameObject water;
    public GameObject chest;
    public int levelCounter = 1;
    int score;

    void Update()
    {
        score = PlayerPrefs.GetInt("HighScore");
        mz = GameObject.Find("Maze");
        water = GameObject.FindWithTag("Water");
        chest = GameObject.FindWithTag("Chest");
    }
    //generates new harder maze when player finds chest
    void OnCollisionEnter(Collision info)
    {
        int row = mz.GetComponent<MazeGenerator>().rows;
        int col = mz.GetComponent<MazeGenerator>().columns;
        if (info.collider.tag == "Chest")
        {
            Destroy(water);
            Destroy(chest);
            levelCounter++;
            if(levelCounter > score)
            {
                PlayerPrefs.SetInt("HighScore", levelCounter);
            }
           
            if(row == col)
            {
                mz.GetComponent<MazeGenerator>().rows++;
            } else
            {
                mz.GetComponent<MazeGenerator>().columns++;
            }
            mz.GetComponent<MazeGenerator>().generateMaze();
        } 
    }
}
