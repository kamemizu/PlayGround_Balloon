using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_U_Ctrl : MonoBehaviour
{
    private bool onGround;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        onGround = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < 2)
        {
            if (onGround)
            {
                if (Input.GetKeyDown(KeyCode.U))
                {
                    rb.AddForce(transform.up * 1000f);
                    //onGround = false;
                }
            }
        }
        else if (transform.position.y > 2)
        {
            rb.velocity = Vector2.zero;
            transform.position = new Vector2(transform.position.x, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }
}
