using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollision : MonoBehaviour
{

    private GameObject coins;
    private GameObject player;
    public AudioClip clip;
    int level;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        coins = GameObject.Find("CoinManager");
        level = player.GetComponent<ChestCollision>().levelCounter;
    }

    void OnTriggerEnter(Collider info)
    {
        if (info.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(clip, new Vector3(5, 1, 2));
            Destroy(transform.gameObject);
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + level);
        } 
    }


}
