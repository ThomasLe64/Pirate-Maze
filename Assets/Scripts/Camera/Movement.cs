using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 1.5f;

    private float inputHorizontal;
    private float inputVertical;

    private string horizontalAxis = "Horizontal";
    private string verticalAxis = "Vertical";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(1 * Time.deltaTime * speed, 0, 0);
        inputHorizontal = SimpleInput.GetAxis(horizontalAxis);
        inputVertical = SimpleInput.GetAxis(verticalAxis);

        transform.Rotate(0, -inputHorizontal * speed, 0f, Space.Self);
    }
}
