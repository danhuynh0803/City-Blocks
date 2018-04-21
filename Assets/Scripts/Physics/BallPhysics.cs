using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour {
    [Header("Adjust Ball Speed here")]
    public float speedY = 10;
    public float speedX = 10;
    Rigidbody2D rigidBody;

    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        Kick();
    }
    public void Kick()
    {
        rigidBody.velocity = new Vector2(0f, -1 * speedY);
    }
    public void Bounce()
    {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, rigidBody.velocity.y * -1);
    }
    public void Bounce(float radian)
    {
        rigidBody.velocity = new Vector2(speedX * Mathf.Cos(radian), rigidBody.velocity.y * -1);
    }
    public void BounceDown()
    {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x , Mathf.Abs(rigidBody.velocity.y) * -1f);
    }
    public void LeftSideBounce()
    {
        rigidBody.velocity = new Vector2(Mathf.Abs(rigidBody.velocity.x), rigidBody.velocity.y);
    }
    public void RightSideBounce()
    {
        rigidBody.velocity = new Vector2(Mathf.Abs(rigidBody.velocity.x) * -1f, rigidBody.velocity.y);
    }
    public void RespawnBall()
    {
        transform.position = new Vector2(0f,0.37f);
    }
}
