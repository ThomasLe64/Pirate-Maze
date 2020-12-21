using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{

    public Text coins;

    // Start is called before the first frame update
    void Start()
    {
        coins.text = PlayerPrefs.GetInt("coins").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        coins.text = "X" + PlayerPrefs.GetInt("coins").ToString();
    }
}
