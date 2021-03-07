using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject nugget;
    public float cameraDistance;
    public float cameraHeight;

    void Update()
    {
        float pos = nugget.transform.position.z;
        transform.position = new Vector3(cameraDistance, cameraHeight, pos);
    }
}
