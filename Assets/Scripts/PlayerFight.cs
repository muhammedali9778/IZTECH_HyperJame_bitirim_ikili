using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFight : MonoBehaviour
{
    private Animator playerAnim;
    private Transform initialRotation;
    // Start is called before the first frame update
    void Start()
    {
        initialRotation = gameObject.transform;
        playerAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
