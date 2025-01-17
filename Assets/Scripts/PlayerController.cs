using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  

    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    private int desiredLane = 0;
    public float laneDistance = 2;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;

        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 2)
            {
                desiredLane = 1;
            }
        }
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    desiredLane++;
        //    if (desiredLane==2)
        //    {
        //        desiredLane = 1;
        //    }
        //}
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    desiredLane--;
        //    if (desiredLane == -2)
        //    {
        //        desiredLane = -1;
        //    }
        //}
        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -2)
            {
                desiredLane = -1;
            }
        }
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane==-1)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if(desiredLane == 1)
        {
            targetPosition += Vector3.right * laneDistance;
        }
        transform.position = Vector3.Lerp(transform.position,targetPosition,2000*Time.deltaTime);
    }
    
    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }
}
