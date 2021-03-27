using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private Animator playerAnim;
    
    private void Start()
    {
        playerAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            playerAnim.SetBool("isAttack", true);
    }

    public void AttackEnded()
    {
        playerAnim.SetBool("isAttack", false);
    }
}
