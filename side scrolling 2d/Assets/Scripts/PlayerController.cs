using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed;

    private Animator anim;
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
        if(horizontalInput > 0.001f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < 0.001f)
        {
            transform.localScale = new Vector3(-1,1,1);
        }



        //karaketer gerak vertikal

        if(Input.GetKey(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x, speed);
        }

        // set anim run
        anim.SetBool("run", horizontalInput !=0 );

        
    }
}
