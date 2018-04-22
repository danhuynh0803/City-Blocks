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
        blocksCount = 0;
        for (int i = 0; i < rows; i++)
       {
            for(int j = 0; j<cols; j++)
            {
                float blockX = offsetX + i * gapX;
                float blockY = offsetY + j * gapY;
                Instantiate(blockPrefab, new Vector2(blockX, blockY), Quaternion.identity);
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
