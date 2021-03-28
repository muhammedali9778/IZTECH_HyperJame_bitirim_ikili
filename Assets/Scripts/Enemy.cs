using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
           //anim.SetBool("isDead",true);
            //StartCoroutine(Wait());
            SceneManager.LoadScene("DeathMenu");
        }
        Debug.Log("Ağaca Değdi.");
    }

    public IEnumerator Wait()
    {
        anim.SetBool("isDead",true);
        yield return new WaitForSeconds(5f);
    }
    
}
