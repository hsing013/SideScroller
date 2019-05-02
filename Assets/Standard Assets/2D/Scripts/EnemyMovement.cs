using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    float x_initial;
    float y_initial;
    float z_initial;
    int frameCount = 0;
    Animator animator;
    Rigidbody2D rigidbody2D;
    private bool m_Grounded;
    private Transform m_GroundCheck;
    private Transform m_CeilingCheck;
    const float k_GroundedRadius = .2f;
    [SerializeField] private LayerMask m_WhatIsGround;
    public GameObject player;
    private bool FacingRight = true;
    private int frameSkip;
    private int attackCooldown = 0;
    public Transform attackPos;
    public LayerMask mask;
    public float attackRange;
    private bool nearPlayer = false;
    void Start()
    {
        x_initial = 1.0f;
        y_initial = transform.position.y;
        z_initial = transform.position.z;
        m_Grounded = true;
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator.SetBool("Ground", m_Grounded);
        player = GameObject.Find("CharacterRobotBoy");
        frameCount = 30;
        attackCooldown = 10;
    }

    

   
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("THIS IS WORKING\n");
        //Vector3 vector3 = new Vector3(0, 0, 0);
        ///Quaternion q = new Quaternion()
        //transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        //transform.position = new Vector3(x_initial, y_initial, z_initial);



        if (frameSkip > 0)
        {
            --frameSkip;
            return;
        }
        float player_x = player.transform.position.x;
        
        if (Vector2.Distance(transform.position, player.transform.position) > 1)
        {
            Debug.Log("I am being called");
            nearPlayer = false;
            if (player_x - transform.position.x < 0.0f)
            {
                if (FacingRight)
                {
                    Flip();
                }
            }
            else
            {
                if (!FacingRight)
                {
                    Flip();
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, x_initial * .5f);
            animator.SetFloat("Speed", Mathf.Abs(x_initial));
            //rigidbody2D.velocity = new Vector2(x_initial * 10.0f, rigidbody2D.velocity.y);
        }
        else
        {
            animator.SetFloat("Speed", 0.0f);
            nearPlayer = true;
        }

        frameSkip = 10;
        //if (frameCount <= 1000)
        //{
        //    ++frameCount;
        //}
        //frameCount = 0;
        //animator.SetBool("Ground", true);
        //animator.SetFloat("Speed", Mathf.Abs(x_initial));
        //if (x_initial > 0)
        //{
        //    rigidbody2D.velocity = new Vector2(x_initial * 10.0f, rigidbody2D.velocity.y);
        //    x_initial *= -1;
        //}
        //else
        //{
        //    rigidbody2D.velocity = new Vector2(x_initial * 10.0f, rigidbody2D.velocity.y);
        //    x_initial *= -1;
        //}

        //if (frameCount >= 60)
        //{
        //    Destroy(this.gameObject);
        //}

    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        FacingRight = !FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void FixedUpdate()
    {
        //Debug.Log("Fixed update of platform 2d is called\n");
        // Read the inputs.
        if (attackCooldown <= 0 && nearPlayer)
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, mask);
            for (int i = 0; i < enemiesToDamage.Length; ++i)
            {
                enemiesToDamage[i].GetComponent<PlayerHealth>().takeDamage(10);
            }
            attackCooldown = 100;
        }
        else
        {
            attackCooldown -= 1;
        }
    }

}
