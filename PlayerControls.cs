using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float JumpMultiplier;
    public Animator anim;
    private bool facingRight;

    void Start()
    {
        facingRight = true;
        rb = GetComponent<Rigidbody2D>(); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetInteger("State", 3); 
        }
        if (Input.GetKeyUp(KeyCode.Space))
          {
            anim.SetInteger("State", 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetInteger("State", 1);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetInteger("State", 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetInteger("State", 2);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetInteger("State", 0);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    
    void FixedUpdate()
    {
        anim = GetComponent<Animator> ();

        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 Movement = new Vector2(moveHorizontal, 0.0f);

        rb.AddForce(Movement * speed);
        Flip(moveHorizontal);

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(new Vector2(0.0f, 10)*JumpMultiplier);

            }
        }
    }
    private void Flip(float moveHorizontal)
    {
        if(moveHorizontal > 0 && !facingRight || moveHorizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;

            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
