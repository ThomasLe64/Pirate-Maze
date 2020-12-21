using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerSave : MonoBehaviour
{

    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject p5;
    public GameObject b2;
    public GameObject b3;
    public GameObject b4;
    public GameObject b5;

    void Start()
    {
        //checks which boats are bought 1 == true 0 == false
        if(PlayerPrefs.GetInt("p2") == 1)
        {
            b2.SetActive(false);
        }
        if(PlayerPrefs.GetInt("p3") == 1)
        {
            b3.SetActive(false);
        }
        if (PlayerPrefs.GetInt("p4") == 1)
        {
            b4.SetActive(false);
        }
        if (PlayerPrefs.GetInt("p5") == 1)
        {
            b5.SetActive(false);
        }
        //marks the start of the boat
        int name = PlayerPrefs.GetInt("Player");
        if(name == 1){
            p1.SetActive(false);
            p2.SetActive(true);
            p3.SetActive(true);
            p4.SetActive(true);
            p5.SetActive(true);
        }
        else if (name == 2)
        {
            p2.SetActive(false);
            p1.SetActive(true);
            p3.SetActive(true);
            p4.SetActive(true);
            p5.SetActive(true);
        }
        else if (name == 3)
        {
            p3.SetActive(false);
            p1.SetActive(true);
            p2.SetActive(true);
            p4.SetActive(true);
            p5.SetActive(true);
        }
        else if (name == 4)
        {
            p4.SetActive(false);
            p1.SetActive(true);
            p2.SetActive(true);
            p3.SetActive(true);
            p5.SetActive(true);
        }
        else if (name == 5)
        {
            p5.SetActive(false);
            p1.SetActive(true);
            p2.SetActive(true);
            p3.SetActive(true);
            p4.SetActive(true);
        }
    }
    //saves the player thats chosen
    public void playerSelect()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        //saves the player thats chosen
        if(name == "Starter Boat Select")
        {
            PlayerPrefs.SetInt("Player", 1);
            p1.SetActive(false);
            p2.SetActive(true);
            p3.SetActive(true);
            p4.SetActive(true);
            p5.SetActive(true);
        }
        else if (name == "Colored Raft Select")
        {
            PlayerPrefs.SetInt("Player", 2);
            p2.SetActive(false);
            p1.SetActive(true);
            p3.SetActive(true);
            p4.SetActive(true);
            p5.SetActive(true);
        }
        else if (name == "Sail Boat Select")
        {
            PlayerPrefs.SetInt("Player", 3);
            p3.SetActive(false);
            p1.SetActive(true);
            p2.SetActive(true);
            p4.SetActive(true);
            p5.SetActive(true);
        }
        else if (name == "Duck Boat Select")
        {
            PlayerPrefs.SetInt("Player", 4);
            p4.SetActive(false);
            p1.SetActive(true);
            p2.SetActive(true);
            p3.SetActive(true);
            p5.SetActive(true);
        }
        else if (name == "Wind Board Select")
        {
            PlayerPrefs.SetInt("Player", 5);
            p5.SetActive(false);
            p1.SetActive(true);
            p2.SetActive(true);
            p3.SetActive(true);
            p4.SetActive(true);
        }
        //Debug.Log(PlayerPrefs.GetInt("Player"));
    }

    public void buy()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        //cost 500 coins
        if (name == "Colored Raft Buy")
        {
            //Debug.Log("b2");
            if (PlayerPrefs.GetInt("coins") >= 500)
            {
                PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - 500);
                PlayerPrefs.SetInt("p2", 1);
                b2.SetActive(false);
            }
        }
        //cost 800 coins
        else if (name == "Sail Boat Buy")
        {
            if (PlayerPrefs.GetInt("coins") >= 1500)
            {
                PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - 1500);
                PlayerPrefs.SetInt("p3", 1);
                b3.SetActive(false);
            }
            // Debug.Log("b3");
        }
        //cost 1100 coins
        else if (name == "Duck Boat Buy")
        {
            //Debug.Log("b4");
            if (PlayerPrefs.GetInt("coins") >= 3000)
            {
                PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - 3000);
                PlayerPrefs.SetInt("p4", 1);
                b4.SetActive(false);
            }
        }
        //cost 1300 coins
        else if (name == "Wind Board Buy")
        {
            //Debug.Log("b5");
            if (PlayerPrefs.GetInt("coins") >= 5000)
            {
                PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - 5000);
                PlayerPrefs.SetInt("p5", 1);
                b5.SetActive(false);
            }
        }

    }
}
