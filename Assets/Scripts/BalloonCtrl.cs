using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonCtrl : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < 0)
        {
            rb.AddForce(new Vector2(100.0f, 0));
        }
        else
        {
            //rb.AddForce(new Vector2(2.0f, 0));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //rb.AddForce(new Vector2(10.0f, 0));
        if (collision.gameObject.tag == "Goal")
        {
            GameManager.state = GameManager.State.Goal;
        } 
    }
}
