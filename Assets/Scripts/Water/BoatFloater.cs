using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatFloater : MonoBehaviour
{
    private Transform seaPlane;
    private Cloth meshPlane;
    [SerializeField]private int index = -1;
    /*
    // Start is called before the first frame update
    void Start()
    {
        seaPlane = GameObject.Find("Water(Clone)").transform;
        if (meshPlane)
        {
            meshPlane = seaPlane.GetComponent<Cloth>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (meshPlane)
        {
            getClosestVertex();
        }
    }
    
    void getClosestVertex()
    {
        if (meshPlane)
        {
            for (int i = 0; i < meshPlane.vertices.Length; i++)
            {
                if (index == -1)
                {
                    index = i;
                }
                float distance = Vector3.Distance(meshPlane.vertices[i], transform.position);
                float closestDistance = Vector3.Distance(meshPlane.vertices[index], transform.position);

                if (distance < closestDistance)
                {
                    index = i;
                }
            }

        }
        transform.localPosition = new Vector3(transform.localPosition.x, meshPlane.vertices[index].y/10, transform.localPosition.z);
    }
    */
}
