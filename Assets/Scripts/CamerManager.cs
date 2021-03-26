using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerManager : MonoBehaviour
{
    public Transform target;
    public float cameraSpeed = 1.0f;

    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Slerp( new Vector3(transform.position.x, transform.position.y, transform.position.z),
                                            new Vector3(target.position.x, target.position.y, target.position.z),
                                           Time.deltaTime * cameraSpeed);
    }
}
