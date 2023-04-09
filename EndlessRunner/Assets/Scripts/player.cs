using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;

    public float speed = 5;
    private Rigidbody2D rb;
    public float jumph = 8;
    public float horizontalMove = 0f;
    public bool facingRight = true;
    private bool isgrounded = false;

    public GameObject panel;

    private Vector3 rot;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rot = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        float richtung = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * speed * richtung * Time.deltaTime);

        if(richtung > 0 && !facingRight) {
            Flip();
        } else if(richtung < 0 && facingRight) {
            Flip();
        }

        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            rb.AddForce(Vector2.up * jumph, ForceMode2D.Impulse);
            isgrounded = false; 
        } 
        
        animator.SetBool("IsGrounded", isgrounded);

        //aus der Map fallen 
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isgrounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "spike")
        {
            panel.SetActive(true);
            Destroy(gameObject);
        }
    }

    void Flip ()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}