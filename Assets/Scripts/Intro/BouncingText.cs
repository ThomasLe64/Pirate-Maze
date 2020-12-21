using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingText : MonoBehaviour
{
    public float speed;
    Vector3 startPos;
    // Start is called before the first frame update
    void Start1()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update1()
    {
        transform.Translate((new Vector3(-1, 0, 0)) * speed * Time.deltaTime);
        if (transform.position.x > 18)
            transform.position = startPos;
    }
}