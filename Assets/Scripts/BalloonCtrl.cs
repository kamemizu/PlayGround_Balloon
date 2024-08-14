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
        rb.AddForce(new Vector2(5.0f, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Goal")
        {
            GameManager.state = GameManager.State.Goal;
        } 
    }
}
