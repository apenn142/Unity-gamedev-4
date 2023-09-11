using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBuildScript : MonoBehaviour
{
    private int[,] grid;
    public GameObject wall, brazier, candle;
    public float xOffset, yOffset;
    //0-NULL
    //1-SQUARE
    //2-TRIANGLE TOP LEFT
    //3-TRIANGLE TOP RIGHT
    //4-TRIANGLE DOWN LEFT
    //5-TRIANGLE DOWN RIGHT
    //6-RECTANGLE TOP
    //7-RECTANGLE DOWN
    //8-RECTANGLE LEFT
    //9-RECTANGLE RIGHT
    // Start is called before the first frame update
    public void StartBuild()
    {
        //startX startY lengthX lengthY
        grid = new int[6, 6];
        BuildSkeleton(0, 0);
        BuildSkeleton(-1, 0);
        BuildSkeleton(1, 0);
        BuildSkeleton(0, 1);
        BuildSkeleton(0, 2);
        BuildSkeleton(1, 2);
        BuildSkeleton(-1, 2);
        BuildSkeleton(-2, 3);
        BuildSkeleton(-1, 3);
        BuildSkeleton(0, 3);
        BuildSkeleton(1, 3);
        BuildSkeleton(2, 3);
        BuildSkeleton(0, 4);
        BuildSkeleton(2, 4);
        BuildSkeleton(3, 4);
        BuildSkeleton(0, 5);
        BuildSkeleton(-1, 5);
        BuildShell();
    }

    public void GenerateDungeon1_0()
    {
        //skeleton (basic room)
        BuildSkeleton(0, 0);
        BuildSkeleton(-1, 0);
        BuildSkeleton(1, 0);
        BuildSkeleton(0, 1);
        BuildSkeleton(0, 2);
        BuildSkeleton(1, 2);
        BuildSkeleton(-1, 2);
        BuildSkeleton(-2, 3);
        BuildSkeleton(-1, 3);
        BuildSkeleton(0, 3);
        BuildSkeleton(1, 3);
        BuildSkeleton(2, 3);
        BuildSkeleton(0, 4);
        BuildSkeleton(2, 4);
        BuildSkeleton(3, 4);
        BuildSkeleton(0, 5);
        BuildSkeleton(-1, 5);
        //shell (outer wall)
        BuildShell();
        //walls

        //doors

        //structures

        //hazards


    }

    private void BuildSkeleton(int xShift, int yShift)
    {
        grid[xShift + 2, yShift] = 1;
        xShift *= 22;
        yShift *= 10;
        Wall(0 + xShift, 0 + yShift, 9, 1);
        Wall(13 + xShift, 0 + yShift, 9, 1);
        Wall(0 + xShift, 0 + yShift, 1, 3);
        Wall(0 + xShift, 7 + yShift, 1, 3);
        Wall(21 + xShift, 0 + yShift, 1, 3);
        Wall(21 + xShift, 7 + yShift, 1, 3);
        Wall(0 + xShift, 9 + yShift, 9, 1);
        Wall(13 + xShift, 9 + yShift, 9, 1);
    }

    private void BuildShell()
    {
        for (int x = 0; x < 6; x++)
        {
            for (int y = 0; y < 6; y++)
            {
                if (grid[x, y] == 1 && (x == 0 || grid[x - 1, y] == 0))
                    Wall((x - 2) * 22, y * 10 + 3, 1, 4);
                if (grid[x, y] == 1 && (x == 5 || grid[x + 1, y] == 0))
                    Wall((x - 2) * 22 + 21, y * 10 + 3, 1, 4);
                if (grid[x, y] == 1 && (y == 0 || grid[x, y - 1] == 0))
                    Wall((x - 2) * 22 + 9, y * 10, 4, 1);
                if (grid[x, y] == 1 && (y == 5 || grid[x, y + 1] == 0))
                    Wall((x - 2) * 22 + 9, y * 10 + 9, 4, 1);
            }
        }
    }

    public void BuildRoom(int x, int y)
    {
        xOffset = ((x + 1) / 2);
        yOffset = ((y + 1) / 2);
        for (int i = 1; i < x; i++)
        {
            Square(i - xOffset, 0 - yOffset);
            Square(i - xOffset, y - yOffset);
        }
        for (int i = 1; i < y; i++)
        {
            Square(0 - xOffset, i - yOffset);
            Square(x - xOffset, i - yOffset);
        }
    }

    private void Wall(int xP, int yP, int xL, int yL)
    {
        for (int x = xP; x < xP + xL; x++)
        {
            for (int y = yP; y < yP + yL; y++)
            {
                Square(x, y);
            }
        }
    }

    public void Square(float x, float y)
    {
        GameObject w = Instantiate(wall, new Vector2(x, y), Quaternion.identity);
        w.GetComponent<SpriteRenderer>().enabled = true;
        w.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void Brazier(int x, int y)
    {
        Instantiate(brazier, new Vector2(x - xOffset, y - yOffset), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
