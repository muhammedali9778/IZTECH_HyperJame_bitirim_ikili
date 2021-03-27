using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnim;
    private Transform initialRotation;

    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    private int desiredLane = 0;
    public float laneDistance = 1;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        initialRotation = gameObject.transform;
        playerAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;

        if (Input.GetKeyUp(KeyCode.Space) && !playerAnim.GetBool("isAttack") && !playerAnim.GetBool("isAttack2") && !playerAnim.GetBool("isDead"))
        {
            if (Random.Range(0, 2) == -1)
            {
                playerAnim.SetBool("isAttack", true);
            }
            else
            {
                playerAnim.SetBool("isAttack2", true);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane==2)
            {
                desiredLane = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
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
    public void AttackEnded()
    {
        gameObject.transform.rotation.Set(initialRotation.rotation.x, initialRotation.rotation.y, initialRotation.rotation.z, initialRotation.rotation.w);
        playerAnim.SetBool("isAttack", false);
        playerAnim.SetBool("isAttack2", false);
    }
    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }
}
