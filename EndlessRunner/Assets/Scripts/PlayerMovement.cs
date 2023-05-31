using JetBrains.Annotations;
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
    private int deathHeight = -10;
    private int score = 0;
    public ScoreDisplayer scoreDisplayer;

    private Vector3 validDirection = Vector3.up;
    private float contactThreshold = 75; 

    public GameOverScreen gameOverScreen;

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
        if(rb.position.y <= deathHeight) DestroyPlayer();

        float direction = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * speed * direction * Time.deltaTime);

        if(direction > 0 && !facingRight) {
            Flip();
        } else if(direction < 0 && facingRight) {
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            for (int k=0; k < collision.contacts.Length; k++)
            {
                if (Vector3.Angle(collision.contacts[k].normal, validDirection) <= contactThreshold)
                {
                    isgrounded = true;
                    break; 
                }
            }
        }

        if(collision.gameObject.tag == "spring")
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector2.up * 30, ForceMode2D.Impulse);
            isgrounded = false;
        }

        if (collision.gameObject.tag == "spike" || collision.gameObject.tag == "laser" || collision.gameObject.tag == "enemy")
        {
            DestroyPlayer();
        }
    }

    void Flip ()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void DestroyPlayer() 
    {
        Destroy(gameObject);
        setScore();
        GameObject gameUi = GameObject.Find("GameUI");
        gameUi.GetComponent<ScoreDisplayer>().SaveHighscore();
        gameOverScreen.Setup(score); 

    }
    public void setScore()
    {
        score = scoreDisplayer.getScore(); 
    }

}