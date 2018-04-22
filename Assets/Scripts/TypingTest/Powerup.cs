using UnityEngine;

public class Powerup : MonoBehaviour {

    public GameObject ball;
    private LevelController levelController;
    #region DecreaseBallSpeed
    [Header("DecreaseBallSpeed")]
    public float decreaseBallSpeedFactor;
    public float decreaseBallSpeedDuration;
    public float maxDecreaseBallSpeedDuration;
    public int DecreaseBallSpeedStack;


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
        Debug.Log("In Powerup functions");
        if (wordLineNum < 5)
        {
            Debug.Log("AddLife");
            AddLife();
        }
        else if (wordLineNum < 10)
        {
            Debug.Log("Paddle");
        }
        else if (wordLineNum < 15)
        {
            Debug.Log("Ballspeed");
        }
        else if (wordLineNum < 20)
        {
            Debug.Log("Bumpers");
        }
        else
        {
            Debug.Log("No powerup associated with this word");
        }
    }

    #region AddLife
    [Header("Life")]
    public int yolo = 0;
    // Add life but do not add if at max lives
    public void AddLife()
    {
        levelController.AddLife();
    }
    #endregion
    #region LengthenPaddle
    [Header("LengthenPaddle")]
    public GameObject playerPaddle;
    public float lengthenDuration;
    public float lengthenScale;
    public Vector3 originalScale;
    public void LengthenPaddle()
    {
        Transform paddleTransform = playerPaddle.transform;
        paddleTransform.localScale = new Vector3(paddleTransform.localScale.x + lengthenScale, paddleTransform.localScale.y, paddleTransform.localScale.z);
    }
    public void ResetScale()
    {
        Transform paddleTransform = playerPaddle.transform;
        paddleTransform.localScale = originalScale;
    }
    #endregion
    #region Bumpers
    [Header("Bumpers")]
    public GameObject bumper;
    public float bumpeDuration;
    public void ToggleBumpers(bool toggle)
    {
        bumper.SetActive(toggle);
    }

    #endregion
    #region Multiplier
    public void AddMultiplier()
    {

    }
    #endregion
    public void Start()
    {
        DecreaseBallSpeedStack = 0;
        levelController = FindObjectOfType<LevelController>();
        originalScale = playerPaddle.transform.localScale;
    }

}
