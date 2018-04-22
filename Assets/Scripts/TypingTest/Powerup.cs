using UnityEngine;

public class Powerup : MonoBehaviour {

    public GameObject ball;

    #region DecreaseBallSpeed
    [Header("DecreaseBallSpeed")]
    public float decreaseBallSpeedFactor;
    public float decreaseBallSpeedDuration;
    public float maxDecreaseBallSpeedDuration;
    public int DecreaseBallSpeedStack;

    private LevelController levelController;
    
    public void SetDecreaseBallSpeedDuration(float time)
    {
        decreaseBallSpeedDuration = Mathf.Clamp(time, 0, maxDecreaseBallSpeedDuration);
    }
    public void SetDecreaseBallSpeed(int stack)
    {
        DecreaseBallSpeedStack = stack;
    }

    public void DecreaseBallSpeedEffect()
    {
        SetDecreaseBallSpeed(DecreaseBallSpeedStack + 1);
        Rigidbody2D ballRidigBody = ball.GetComponent<Rigidbody2D>();
        BallPhysics ballPhysics = ball.GetComponent<BallPhysics>();
        ballPhysics.SetSpeedX(ballPhysics.speedX * decreaseBallSpeedFactor);
        ballPhysics.SetSpeedY(ballPhysics.speedY * decreaseBallSpeedFactor);
        SetDecreaseBallSpeedDuration(30);
        ballRidigBody.velocity = new Vector2(ballRidigBody.velocity.x * decreaseBallSpeedFactor, ballRidigBody.velocity.y * decreaseBallSpeedFactor);
    }

    public void DecreaseBallSpeedClearBuff()
    {
        Rigidbody2D ballRidigBody = ball.GetComponent<Rigidbody2D>();
        BallPhysics ballPhysics = ball.GetComponent<BallPhysics>();
        ballPhysics.SetSpeedX(ballPhysics.InitalSpeedX);
        ballPhysics.SetSpeedY(ballPhysics.InitalSpeedY);
        ballRidigBody.velocity = new Vector2(ballRidigBody.velocity.x / Mathf.Pow(decreaseBallSpeedFactor, DecreaseBallSpeedStack), ballRidigBody.velocity.y / Mathf.Pow(decreaseBallSpeedFactor, DecreaseBallSpeedStack));
        DecreaseBallSpeedStack = 0;
        decreaseBallSpeedDuration = 0;
    }
    #endregion

    public void ActivatePowerup(int wordLineNum)
    {
        if (wordLineNum < 5)
        {
            AddLife();
        }
        else if (wordLineNum < 10)
        {

        }
        else if (wordLineNum < 15)
        {
        
        }
        else if (wordLineNum < 20)
        {

        }
        else
        {
            Debug.Log("No powerup associated with this word");
        }
    }

    // Add life but do not add if at max lives
    public void AddLife()
    {
        levelController.AddLife();
    }

    public void LengthenPaddle()
    {

    }

    public void AddBumpers()
    {

    }

    public void AddMultiplier()
    {

    }

    public void Start()
    {
        DecreaseBallSpeedStack = 0;
        levelController = FindObjectOfType<LevelController>();
    }
}
