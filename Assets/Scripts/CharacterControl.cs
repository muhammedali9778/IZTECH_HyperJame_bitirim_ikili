using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private Animator playerAnim;
    private Transform initialRotation;
    private float touchStart;
    public GameObject parent;
    
    private void Start()
    {
        initialRotation = gameObject.transform;
        playerAnim = gameObject.GetComponent<Animator>();
    }


    private void SwipeLeft()
    {
        parent.transform.position = Vector3.Slerp(
            new Vector3(parent.transform.position.x, parent.transform.position.y, parent.transform.position.y),
            new Vector3(parent.transform.position.x - 2, parent.transform.position.y, parent.transform.position.y), 0.5f);
    }

    private void SwipeRight()
    {
        parent.transform.position = Vector3.Slerp(
            new Vector3(parent.transform.position.x, parent.transform.position.y, parent.transform.position.y),
            new Vector3(parent.transform.position.x + 2, parent.transform.position.y, parent.transform.position.y), 0.5f);
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            touchStart = Input.mousePosition.x;

        if (Input.GetMouseButtonUp(0))
        {
            float delta = Input.mousePosition.x - touchStart;
            if (delta < -200.0f)
                SwipeLeft();
            else if (delta > 200.0f)
                SwipeRight();
        }

        if (Input.GetKeyUp(KeyCode.Space) && !playerAnim.GetBool("isAttack") && !playerAnim.GetBool("isAttack2") && !playerAnim.GetBool("isDead"))
        {
            if (Random.Range(0, 2) == 0)
            {
                playerAnim.SetBool("isAttack", true);
            }
            else
            {
                playerAnim.SetBool("isAttack2", true);
            }
        }
    }

    public void AttackEnded()
    {
        gameObject.transform.rotation.Set(initialRotation.rotation.x, initialRotation.rotation.y, initialRotation.rotation.z, initialRotation.rotation.w);
        playerAnim.SetBool("isAttack", false);
        playerAnim.SetBool("isAttack2", false);
    }
}
