using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D body;
    // Start is called before the first frame update
    private void Start()
    {
        anim=GetComponent<Animator>();
        body=GetComponent<Rigidbody2D>();

    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.tag == "Enemy")
         {
             Die();
         }
    }

    private void Die()
    {
        body.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void restartLev()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
