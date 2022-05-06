using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementScript : MonoBehaviour
{   
    public float speed;
    private Animator anim;
    private Rigidbody2D body; 
    private bool grounded;
    private int Dia = 0;
    [SerializeField] private Text DiamondText ;
    
   
    private void Awake()
    {
       body = GetComponent<Rigidbody2D> ();
       anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
      float HorizontalInput = Input.GetAxis("Horizontal");
      body.velocity = new Vector2( HorizontalInput * speed, body.velocity.y);
       //Flipp player when moving left/right
        if  (HorizontalInput> 0.01f)
            transform.localScale =new Vector3(2,2,2);
        else if (HorizontalInput< -0.01f)
            transform.localScale = new Vector3(-2, 2 , 2);    
        
     if  (Input.GetKey(KeyCode.Space)&& grounded ) 
         jump();

    //set animator parameters
     anim.SetBool("walk", HorizontalInput !=0); 
     anim.SetBool("grounded", grounded);
    }

    private void jump()
    { 
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.tag == "Ground")
         grounded = true;

      if (collision.gameObject.tag =="SG")
         speed = speed +3;
         
    }
    public bool canAttack()
    {
       return true;
    }




    void OnTriggerEnter2D(Collider2D other)
{
    if (other.gameObject.CompareTag("Diamond"))
    {
        other.gameObject.SetActive(false);
        Dia++;
        DiamondText.text = "Diamonds: "+ Dia;
    }
}
}
