using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    /*
    public Vector3 offset;
    private GameObject player;


    void LateUpdate()
    {
        if (player == null)
        {
            player = GameObject.Find("Player(Clone)");
        }
        else
        {
            transform.position = player.transform.position + offset;
            transform.rotation = player.transform.rotation * Quaternion.Euler(new Vector3(0, 90, 0)); 
        }
    }
    */

    private GameObject player;

    //locking the camera onto the player
    void LateUpdate()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        } else
        {
            transform.parent = player.transform;
        }
    }
}
