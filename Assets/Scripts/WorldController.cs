using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{

    public Vector2 levelSize;
    public GameObject tile;

    public int arrayLength;
    public string[] spriteNames;
    public Sprite[] dirt;
    public Sprite[] grass;
    public Sprite[] stone;
    public Sprite[] sand;
    public Sprite[] ice;
    public Sprite[] water;

    public Sprite[,] groundSprites;

    void Start ()
    {
        SetArray();
        GenerateTiles();
    }

    void SetArray ()
    {
        groundSprites = new Sprite[arrayLength, Mathf.Max(water.Length, Mathf.Max(ice.Length, Mathf.Max(sand.Length, Mathf.Max(stone.Length, Mathf.Max(dirt.Length, grass.Length)))))];
        for (int x = 0; x <= groundSprites.GetLength(1) - 1; x++)
        {
            groundSprites[0, x] = dirt[x];
        }
        for (int x = 0; x <= groundSprites.GetLength(1) - 1; x++)
        {
            groundSprites[1, x] = grass[x];
        }
        for (int x = 0; x <= groundSprites.GetLength(1) - 1; x++)
        {
            groundSprites[2, x] = stone[x];
        }
        for (int x = 0; x <= groundSprites.GetLength(1) - 1; x++)
        {
            groundSprites[3, x] = sand[x];
        }
        for (int x = 0; x <= groundSprites.GetLength(1) - 1; x++)
        {
            groundSprites[4, x] = ice[x];
        }
        for (int x = 0; x <= groundSprites.GetLength(1) - 1; x++)
        {
            groundSprites[5, x] = water[x];
        }
    }

    void GenerateTiles ()
    {
        int xLevelSize = Mathf.RoundToInt(levelSize.x);
        int yLevelSize = Mathf.RoundToInt(levelSize.y);

        for (int i = xLevelSize * -1; i <= xLevelSize; i++)
        {
            for (int j = yLevelSize * -1; j <= yLevelSize; j++)
            {
                GameObject temp = Instantiate(tile, transform);
                temp.GetComponent<TileController>().coordinates = new Vector2(i, j);
                temp.name = "Tile " + new Vector2(i, j).ToString();
            }
        }

    }

}
