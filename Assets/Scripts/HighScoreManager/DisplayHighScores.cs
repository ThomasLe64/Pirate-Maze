using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayHighScores : MonoBehaviour
{

    public Text[] highscoreText;
    OnlineHighScores highsoreManager;
    // Start is called before the first frame update
    void Start()
    {
        for(int index = 0; index < highscoreText.Length; index++)
        {
            highscoreText[index].text = index + 1 + ". Fetching...";
        }

        highsoreManager = GetComponent<OnlineHighScores>();

        StartCoroutine("RefreshHighscores");
    }

    public void OnHighScoresDownloaded(Highscore[] highscoreList)
    {
        for (int index = 0; index < highscoreText.Length; index++)
        {
            highscoreText[index].text = index + 1 + ". ";
            if(highscoreList.Length > index)
            {
                highscoreText[index].text += highscoreList[index].username + " - " + highscoreList[index].score;
            }
        }
    }

    IEnumerator RefreshHighscores()
    {
        while (true)
        {
            highsoreManager.DownloadHighScores();
            yield return new WaitForSeconds(30);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
