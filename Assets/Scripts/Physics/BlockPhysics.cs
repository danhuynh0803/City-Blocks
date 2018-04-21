using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPhysics : MonoBehaviour {

    public Block block;
    bool isHitted;

    void Start()
    {
        block = new Block(transform.position.x, transform.position.y);

    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball" && !isHitted)
        {
            collision.gameObject.GetComponent<BallPhysics>().Bounce();
            isHitted = true;
            Kill();
        }

    }
    void Kill()
    {
        Destroy(gameObject);
    }
}
