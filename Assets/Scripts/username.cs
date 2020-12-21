using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class username : MonoBehaviour
{

    public string name;
    public GameObject inputField;
    public GameObject inputfeildObject;
    public GameObject dispaly;
    public GameObject submit;
    public GameObject ask;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetString("username"));
        //check if playerpref username has a value,if it does, then dont dispaly the submit button and text
        if (PlayerPrefs.HasKey("username"))
        {
            dispaly.GetComponent<Text>().text = "Welcome " + PlayerPrefs.GetString("username");
            inputField.SetActive(false);
            submit.SetActive(false);
            ask.SetActive(false);
            inputfeildObject.SetActive(false);
        } else
        {
            inputField.SetActive(true);
            submit.SetActive(true);
            ask.SetActive(true);
            inputfeildObject.SetActive(true);
        }
    }

    public void storeName()
    {
        Debug.Log(PlayerPrefs.GetString("username"));
        name = inputField.GetComponent<Text>().text;
        PlayerPrefs.SetString("username", name);
        dispaly.GetComponent<Text>().text = "Welcome " + name;
        inputField.SetActive(false);
        submit.SetActive(false);
        ask.SetActive(false);
        inputfeildObject.SetActive(false);
    }


}
