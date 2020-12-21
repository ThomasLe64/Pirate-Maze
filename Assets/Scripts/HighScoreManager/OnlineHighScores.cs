using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class OnlineHighScores : MonoBehaviour
{

    public static bool allowHTTPDownload = true;

    const string privateCode = "Lfj-WEbTxESqnYCcuRrMAQ6BlFG6I3pkmKYgUXJqUNPw";
    const string publiceCode = "5f2c53beeb371809c4b194bb";
    const string webURL = "http://dreamlo.com/lb/";

    public Highscore[] highscoreList;
    static OnlineHighScores instance;
    DisplayHighScores highscoresDisplay;

    private string uname;
    private int score;

    //test
    void Awake()
    {
        instance = this;
        uname = PlayerPrefs.GetString("username");
        score = PlayerPrefs.GetInt("HighScore");
        highscoresDisplay = GetComponent<DisplayHighScores>();
        AddNewHighScore(uname, score);

    }
    //
    //

    public static void AddNewHighScore(string username, int score)
    {
        instance.StartCoroutine(instance.UploadNewHighScore(username, score));
    }

    //uploads new highscore dreamlo
    IEnumerator UploadNewHighScore(string username, int score)
    {
        UnityWebRequest www = new UnityWebRequest(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            print("Upload Success");
            DownloadHighScores();
        } else
        {
            print("Error uploading" + www.error);
        }
    }

    //downloads highscores from dreamlo database
    public void DownloadHighScores()
    {
        StartCoroutine("DownloadHighScoreFromDatabase");
    }

    IEnumerator DownloadHighScoreFromDatabase()
    {
        WWW www = new WWW(webURL + publiceCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighScores(www.text);
            highscoresDisplay.OnHighScoresDownloaded(highscoreList);
        }
        else
        {
            print("Error downloading" + www.error);
        }
    }

    void FormatHighScores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoreList = new Highscore[entries.Length];
        for(int index = 0; index < entries.Length; index++)
        {
            string[] entryinfo = entries[index].Split(new char[] { '|' });
            string username = entryinfo[0];
            int score = int.Parse(entryinfo[1]);
            highscoreList[index] = new Highscore(username, score);
        }
    }
}

public struct Highscore
{
    public string username;
    public int score;

    public Highscore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }
}
