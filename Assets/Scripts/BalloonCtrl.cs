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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.right * 1000.0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Goal")
        {
            GameManager.state = GameManager.State.Result;
        } 
    }
}
