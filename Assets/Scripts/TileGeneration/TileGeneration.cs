using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Tilemaps;



public class TileGeneration : MonoBehaviour
{
    public int width;
    public int height;

    [Range(0,100)]
    public int randomFillPercent;
    public int smoothNum;
    int[,] map;

    public string seed;
    public bool randomSeed;

    private void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        map = new int[width,height];
        RandomFillMap();
        for(int i = 0; i < smoothNum; i++)
        {
            SmoothMap();
        }
    }

    void RandomFillMap()
    {
        if(randomSeed)
        {
            seed = Time.time.ToString();
        }
        System.Random randNumGen = new System.Random(seed.GetHashCode());

        for(int x = 0; x < width; x++)
        {
            for(int y =0; y < height; y++)
            {
                if(x == 0 || x == width -1 || y == 0 || y == height -1)
                {
                    map[x, y] = 1;
                }
                else if((randNumGen.Next(0, 100) < randomFillPercent))
                {
                    map[x, y] = 1;
                }
                else if((randNumGen.Next(0, 100) == randomFillPercent))
                {
                    map[x, y] = 2;
                }
                else
                {
                    map[x, y] = 0;
                }
            }
        }
    }

    void SmoothMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int neighbourwallTiles = GetSurroundingWallCount(x, y);
                if(neighbourwallTiles > 4)
                {
                    map[x,y] = 1;
                }
                else if (neighbourwallTiles < 4)
                {
                    map[x, y] = 0;
                }
            }
        }
    }

    int GetSurroundingWallCount(int gridX, int gridY)
    {
        int wallCount = 0;
        for (int neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX++)
        {
            for (int neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY++)
            {
                if (neighbourX >= 0 && neighbourX < width && neighbourY >= 0 && neighbourY < height)
                {
                    if (neighbourX != gridX || neighbourY != gridY)
                    {
                        wallCount += map[neighbourX, neighbourY];
                    }
                }
                else
                {
                    wallCount++;
                }
            }
        }

        return wallCount;
    }

    void OnDrawGizmos()
    {
        if (map != null)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (map[x, y] == 1)
                    {
                        Gizmos.color = Color.black;
                    }
                    else if (map[x, y] == 2)
                    {
                        Gizmos.color = Color.red;
                    }
                    else
                    {
                        Gizmos.color = Color.white;
                    }

                    Vector3 pos = new Vector3(-width / 2 + x + .5f, -height / 2 + y + .5f,0);
                    Gizmos.DrawCube(pos, Vector3.one);
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {


    }


}
