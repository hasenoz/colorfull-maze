using UnityEngine;
using System.Collections.Generic;

public class MazeGenerator : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public GameObject wallPrefab;
    private bool[,] visited;
    private int[,] mazeGrid;

    void Start()
    {
        InitializeMaze();
        GenerateMaze(0, 0);
        DrawMaze();
    }

    void InitializeMaze()
    {
        visited = new bool[width, height];
        mazeGrid = new int[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                mazeGrid[x, y] = 1;  // Assume all cells are walls
            }
        }
    }

    void GenerateMaze(int x, int y)
    {
        visited[x, y] = true;
        mazeGrid[x, y] = 0;  // Mark this cell as a passage

        List<Vector2Int> neighbors = new List<Vector2Int>
        {
            new Vector2Int(1, 0),
            new Vector2Int(0, 1),
            new Vector2Int(-1, 0),
            new Vector2Int(0, -1)
        };
        Shuffle(neighbors);  // Randomize neighbors order

        foreach (Vector2Int dir in neighbors)
        {
            int nx = x + dir.x * 2;
            int ny = y + dir.y * 2;
            if (IsInBounds(nx, ny) && !visited[nx, ny])
            {
                mazeGrid[nx - dir.x, ny - dir.y] = 0;  // Remove wall between cells
                GenerateMaze(nx, ny);
            }
        }
    }

    void DrawMaze()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (mazeGrid[x, y] == 1)
                {
                    Instantiate(wallPrefab, new Vector3(x, y, 0), Quaternion.identity);
                }
            }
        }
    }

    bool IsInBounds(int x, int y)
    {
        return x >= 0 && x < width && y >= 0 && y < height;
    }

    void Shuffle<T>(List<T> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
