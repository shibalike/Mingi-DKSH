using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgGenerator : MonoBehaviour
{
    public GameObject wallPrefab; //��Ʋ
    public GameObject[] bgPrefab; //�� ������
    public GameObject vertical; //��(����
    public GameObject landscape; //��(����
    public int N; //Ƚ��
    int[][] map; //��ġ���� Ȯ�� �뵵 
    int mapRand = 0; //�� ������ ������
    void Start ()
    {
        map = new int[100][]; //�� 100 * 100 ũ���� 2���� �迭 ����
        for(int i = 0; i < 100; i++)
        {
            map[i] = new int[100];
            for(int j = 0; j < 100; j++)
                map[i][j] = 0;
        }
        //0�� �� ��, 1�� ��, 2�� ��
        map[50][50] = 1; //���۹�
        GameObject G = Instantiate(wallPrefab);
        G.transform.position = new Vector3(2150, 2150, 0);
        mapRand = Random.Range(0, 6); 
        GameObject BG = Instantiate(bgPrefab[mapRand]);
        BG.transform.position = new Vector3(2150, 2150, 0);
        mapArrange();
        
    }

    void mapArrange()
    {
        int y = 50, x = 50;
        int roadY, roadX;
        int roadRotater;
        int prior_mapRand = -1;
        int priorDir = -1; //���� ����
        for (int i = 0; i < N; i++)
        {
            int dir = Random.Range(0, 4);

            mapRand = Random.Range(0, 6);
            if(mapRand == prior_mapRand)
            {
                mapRand = Random.Range(0, 6);
                prior_mapRand= mapRand;
            }
            else prior_mapRand = mapRand;

            if (dir == 0)
            {
                map[y - 1][x] = 2;
                map[y - 2][x] = 1;
                roadY = y - 1;
                roadX = x;
                y -= 2;
                roadRotater = 0;
            }
            else if (dir == 1)
            {
                map[y][x - 1] = 2;
                map[y][x - 2] = 1;
                roadY = y;
                roadX = x - 1;
                x -= 2;
                roadRotater = 1;    
            }
            else if (dir == 2)
            {
                map[y + 1][x] = 2;
                map[y + 2][x] = 1;
                roadY = y + 1;
                roadX = x;
                y += 2;
                roadRotater = 0;
            }
            else
            {
                map[y][x + 1] = 2;
                map[y][x + 2] = 1;
                roadY = y;
                roadX = x + 1;
                x += 2;
                roadRotater = 1;
            }

            if (map[x][y] == 0 && map[roadX][roadY] == 0)
            {
                GameObject room = Instantiate(wallPrefab);
                room.transform.position = new Vector3(x * 43, y * 43, 0);
                GameObject BG = Instantiate(bgPrefab[mapRand]);
                BG.transform.position = new Vector3(x * 43, y * 43, 0);

                if (roadRotater == 0)
                {
                    GameObject vert = Instantiate(vertical);
                    vert.transform.position = new Vector3(roadX * 43, roadY * 43, 0);
                }
                else
                {
                    GameObject land = Instantiate(landscape);
                    land.transform.position = new Vector3(roadX * 43, roadY * 43, 0);
                }
                map[x][y] = 1;
                map[roadX][roadY] = 2;
                for(int j = 0; j < 4; j++)
                {
                    if(j == dir || j == priorDir)
                    {
                        if (j == 0)
                        {
                            GameObject obj1 = room.transform.Find("fakeWall(land (1)").gameObject; // Object�� �̸��� ã��. ���� ó���� ������ Object�� ��ȯ.
                            obj1.SetActive(false);
                        }
                    }
                }
                priorDir = dir;
            }
            else
            {
                i -= 1; 
                if (dir == 0)
                {
                    roadY = y + 1;
                    y += 2;
                }
                else if (dir == 1)
                {
                    roadX = x + 1;
                    x += 2;
                }
                else if (dir == 2)
                {
                    roadY = y - 1;
                    y -= 2;
                }
                else
                {
                    roadX = x - 1;
                    x -= 2;
                }
            }
        }
    }
} 