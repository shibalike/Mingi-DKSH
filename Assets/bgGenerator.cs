using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgGenerator : MonoBehaviour
{
    public GameObject bgPrefab;
    public GameObject vertical;
    public GameObject landscape;
    public GameObject player; 
    public int N;
    int[][] map;
    void Start ()
    {
        map = new int[100][]; //맵 9 * 9 크기의 2차원 배열 생성
        for(int i = 0; i < 100; i++)
        {
            map[i] = new int[100];
            for(int j = 0; j < 100; j++)
                map[i][j] = 0;
        }
        //0은 빈 곳, 1은 방, 2는 길
        map[50][50] = 1;
        GameObject G = Instantiate(bgPrefab);
        G.transform.position = new Vector3(2150, 2150, 0);
        mapArrange();
        
    }

    void mapArrange()
    {
        int y = 50, x = 50;
        int roadY, roadX;
        int rotater;
        for (int i = 0; i < N; i++)
        {
            int dir = Random.Range(0, 4);
            if (dir == 0)
            {
                map[y - 1][x] = 2;
                map[y - 2][x] = 1;
                roadY = y - 1;
                roadX = x;
                y -= 2;
                rotater = 0;
            }
            else if (dir == 1)
            {
                map[y][x - 1] = 2;
                map[y][x - 2] = 1;
                roadY = y;
                roadX = x - 1;
                x -= 2;
                rotater = 1;
            }
            else if (dir == 2)
            {
                map[y + 1][x] = 2;
                map[y + 2][x] = 1;
                roadY = y + 1;
                roadX = x;
                y += 2;
                rotater = 0;
            }
            else
            {
                map[y][x + 1] = 2;
                map[y][x + 2] = 1;
                roadY = y;
                roadX = x + 1;
                x += 2;
                rotater = 1;
            }

            if (map[x][y] == 0 && map[roadX][roadY] == 0)
            {
                GameObject G = Instantiate(bgPrefab);
                G.transform.position = new Vector3(x * 43, y * 43, 0);
                
                if (rotater == 0)
                {
                    GameObject vert = Instantiate(vertical);
                    vert.transform.position = new Vector3(roadX * 43, roadY * 43, 0);
                }
                else
                {
                    GameObject land = Instantiate(landscape);
                    land.transform.position = new Vector3(roadX * 43, roadY * 43, 0);
                }
            }
            else
                i -= 1;
        }
    }
}