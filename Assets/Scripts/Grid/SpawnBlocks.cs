using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour {
    [Header("Left bottom block spawn postition")]
    public float offsetX;
    public float offsetY;
    [Header("From block center to center")]
    public float gapX;
    public float gapY;
    public GameObject blockPrefab;
    public int rows;
    public int cols;
    public static int blocksCount;
    public static int blocksHit;
    public GameObject ball;

    public float saturation = 1.0f;
    public float value = 1.0f;

    public Color[] blockColors; 

    void Start()
    {
        blocksHit = 0;
        blocksCount = 0;
        Spawn();
    }
    void Update()
    {
        if(blocksCount <= 0)
        {
            ball.GetComponent<BallPhysics>().RespawnBall();
            Spawn();
        }
    }

    void Spawn()
    {
        SoundController.Play((int)SFX.ClearBoard);
        blocksCount = 0;
        for (int i = 0; i < rows; i++)
       {
            for(int j = 0; j<cols; j++)
            {
                float blockX = offsetX + i * gapX;
                float blockY = offsetY + j * gapY;
                GameObject block =Instantiate(blockPrefab, new Vector2(blockX, blockY), Quaternion.identity);
                // Set color based on rows
                block.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(Mathf.Lerp(0.53f, 0.76f, (float)j/cols), saturation, value);
                //block.GetComponent<SpriteRenderer>().material.color = blockColors[i % 3];
                blocksCount++;
            }
       }
    }
    public static void BlockHit()
    {
        blocksCount--;
        blocksHit++;
    }
}
