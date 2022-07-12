using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed;

    private Animator anim;

     private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        //get referance 
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        body.velocity = new Vector2 (horizontalInput * speed, body.velocity.y); 

        //flip gambar char
        if(horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        else if (horizontalInput < -0.01f) //kalau belum input apa2 berarti karakter 0 dan 0<0.01 jadi flip
        {
            transform.localScale = new Vector3(-1,1,1);
        }

        //karaketer gerak vertikal

        if(Input.GetKey(KeyCode.Space) && grounded) 
        {
            Jump();
        }

        // set anim run
        anim.SetBool("run", horizontalInput !=0 );
        anim.SetBool("grounded", grounded);

    }
       
    private void Jump()
        {
            body.velocity = new Vector2(body.velocity.x, speed);
            anim.SetTrigger("jump");
            grounded = false;

        }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
