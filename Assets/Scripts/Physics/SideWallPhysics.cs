using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWallPhysics : MonoBehaviour {

    public float hitTIme = 1f;
    bool isHitted;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball" && !isHitted)
        {
            collision.gameObject.GetComponent<BallPhysics>().SideBounce();
            isHitted = true;
            StartCoroutine(ResetHit(hitTIme));
        }
    }
    IEnumerator ResetHit(float hitTime)
    {
        yield return new WaitForSeconds(hitTime);
        isHitted = false;
    }
}
