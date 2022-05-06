using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed=5f;
    private float mvm=0f;
    private Rigidbody2D rigidbody;
    public float jumpSpeed=7f;
    public Transform GroundCheckPoint;
    public LayerMask groundlayer;
    private bool isTouchingGround;
    public float GroundCheckRadius;
    public Animator animator;
    public bool Jump=false;


    void Start()
    {
    
    rigidbody = GetComponent<Rigidbody2D> ();  
    animator = GetComponent<Animator> ();
    }

 
    void Update()
    {
      
       mvm=Input.GetAxis("Horizontal");
       animator.SetFloat("speed", Mathf.Abs(mvm));

       //Jump=true;
       
       if (mvm > 0f){
        rigidbody.velocity=new Vector2(mvm * speed, rigidbody.velocity.y);
        transform.localScale = new Vector2 (5,5);
         }
        else if (mvm < 0f){
        	rigidbody.velocity= new Vector2(mvm * speed, rigidbody.velocity.y);
            transform.localScale = new Vector2 (-5,5);
        } 
        else
        {
        	rigidbody.velocity = new Vector2 (0, rigidbody.velocity.y);
        }



       
    isTouchingGround=Physics2D.OverlapCircle(GroundCheckPoint.position, GroundCheckRadius, groundlayer);
    animator.SetBool("isJumping",isTouchingGround);
       
    if (Input.GetButtonDown("Jump")&& isTouchingGround){
    	rigidbody.velocity=new Vector2(rigidbody.velocity.x,jumpSpeed);
    }
    void Onlanding() {
    	animator.SetBool("isJumping",false);
    }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
    	if (other.gameObject.CompareTag("coin")){
    		Destroy(other.gameObject);
    	}
    }
}
