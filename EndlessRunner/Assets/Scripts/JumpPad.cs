using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    private float bounce = 20f; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // collision.gameObject.getComponent<Rigidbody2D>().AddForce(Vector.up * bounce, ForceMode2D.Impulse); 
        }
    }
}
