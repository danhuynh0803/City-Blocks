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

    void Start()
    {
        Spawn();
    }
    void Spawn()
    {
       for(int i = 0; i < rows; i++)
       {
            for(int j = 0; j<cols; j++)
            {
                float blockX = offsetX + i * gapX;
                float blockY = offsetY + j * gapY;
                Instantiate(blockPrefab, new Vector2(blockX, blockY), Quaternion.identity);
            }
       }
    }
}
