using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text score;

    // Start is called before the first frame update
    void Start()
    {
        score.text = "HIGHEST MAZE LEVEL: " + PlayerPrefs.GetInt("HighScore").ToString();
    }
}
