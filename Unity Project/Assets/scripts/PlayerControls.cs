using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    float speed;
    float speedOri;

    SpriteRenderer Spr;
    float distance;
    [SerializeField]
    LayerMask GroundLayer;
    [SerializeField]
    float JumpForce;

    Vector2 dir;

    bool isLerping = false;
    bool onLadder = false;

    Rigidbody2D rb;

    BoxCollider2D col;

    Vector2 CrouchSize, CrouchOffset, StandingSize;
    Animator An;
    
    bool NotAbletoJump, InDoor;

    void Start()
    {
        NotAbletoJump = false;
        InDoor = false;
        Spr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        An = GetComponent<Animator>();
        CrouchSize = new Vector2(col.size.x,col.size.y * 0.5f);
        CrouchOffset = new Vector2(0 , 0.5f);
        StandingSize = col.size;
        distance = gameObject.transform.localScale.y*1f;
        speedOri = speed;

        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position,Vector2.down*distance,Color.green);

        if (!NotAbletoJump)
            Jump();
        if(!InDoor)
        {
            Crouch();
            Movement();
        }
        ExitDoor();
        ClimbDown();

        if (isLerping)
            transform.position = Vector2.Lerp(transform.position, dir, 10 * Time.deltaTime);

        if (IsGrounded() && !(Input.anyKey))
            An.SetInteger("animation", 0);

    }

    public AudioSource aS;

    void Movement()
    {
        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            gameObject.transform.Translate(-speed * Time.deltaTime, 0 , 0 );
            Spr.flipX = true;
            An.SetInteger("animation", 2);
            aS.Play();

        }else if(Input.GetAxisRaw("Horizontal") > 0)
        {
            gameObject.transform.Translate( speed * Time.deltaTime, 0 , 0 );
            Spr.flipX = false;
            An.SetInteger("animation", 2);
            aS.Play();
        }
    }
    
    bool IsGrounded()
    {
        if(Physics2D.Raycast(transform.position, Vector2.down, distance, GroundLayer.value))
            return true;
        else
        {
            return false;
        }
    }

    void Jump()
    {
        if (IsGrounded() && Input.GetAxisRaw("Vertical") > 0)
        {
            rb.velocity = Vector2.up * JumpForce;
            An.SetInteger("animation",1);
        }  
    }

    void Crouch()
    {
        if(Input.GetAxis("Vertical") < 0)
        {
            speed = speedOri * 0.25f;
            col.size = CrouchSize;
            col.offset = CrouchOffset;
            An.SetInteger("animation", 3);
        }
        if(Input.GetAxis("Vertical") == 0)
        {
            speed = speedOri;
            col.size = StandingSize;
            col.offset = new Vector2(0, 2.479907f);
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.CompareTag("Door"))
        {
            An.SetInteger("animation", 5);
            NotAbletoJump = true;
            if(Input.GetAxisRaw("Vertical")>0 && rb.velocity == Vector2.zero)
            {
                isLerping = true;
                dir = other.transform.position;
                //transform.position = new Vector2(other.transform.position.x,other.transform.position.y);
                rb.isKinematic = true;
                col.enabled = false;
                InDoor = true;
                print("true");
            }

        }else if (other.CompareTag("Ladder"))
        {
            NotAbletoJump = true;
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                rb.velocity = Vector2.zero;
                rb.isKinematic = true;
                transform.Translate(0, speed * Time.deltaTime, 0);
                onLadder = true;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Door"))
        {
            NotAbletoJump = false;
        }
        else if (other.CompareTag("Ladder"))
        {
            rb.isKinematic = false;
            NotAbletoJump = false;
        }
    }

    void ClimbDown()
    {
        if (onLadder)
        {
            if (Input.GetAxisRaw("Vertical") < 0)
                transform.Translate(0, -speed * Time.deltaTime, 0);
            if (IsGrounded())
            {
                rb.isKinematic = false;
                onLadder = false;
            }
        }
    }

    void ExitDoor()
    {
        if(InDoor)
        {
            if(Input.GetAxisRaw("Vertical")<0)
            {
                isLerping = false;
                col.enabled = true;
                rb.isKinematic = false;
                print("congrats");
                InDoor = false;
            }
        }
    }
}
