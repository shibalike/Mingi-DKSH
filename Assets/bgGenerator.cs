using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgGenerator : MonoBehaviour
{
    public GameObject wallPrefab; //방틀
    public GameObject[] bgPrefab; //방 디자인
    public GameObject vertical; //길(세로
    public GameObject landscape; //길(가로
    public int N; //횟수
    int[][] map; //겹치는지 확인 용도 
    int mapRand = 0; //방 디자인 결정자
    void Start ()
    {
        map = new int[100][]; //맵 100 * 100 크기의 2차원 배열 생성
        for(int i = 0; i < 100; i++)
        {
            map[i] = new int[100];
            for(int j = 0; j < 100; j++)
                map[i][j] = 0;
        }
        //0은 빈 곳, 1은 방, 2는 길
        map[50][50] = 1; //시작방
        GameObject room = Instantiate(wallPrefab);
        room.transform.position = new Vector3(2150, 2150, 0);
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
        int priorDir = -1; //이전 방향
        GameObject priorRoom = null;   
        for (int i = 0; i < N; i++)
        {
            int dir = Random.Range(0, 4); // 방향 정하기

            for (int j = 0; j < 4; j++)
            {
                if (j == dir)
                {
                    if (j == 0)
                    {
                        GameObject obj1 = priorRoom.transform.Find("0").gameObject; // Object의 이름을 찾음. 가장 처음에 나오는 Object를 반환.
                        obj1.SetActive(false);
                    }
                    else if (j == 1)
                    {
                        GameObject obj1 = priorRoom.transform.Find("1").gameObject;
                        obj1.SetActive(false);
                    }
                    else if (j == 2)
                    {
                        GameObject obj1 = priorRoom.transform.Find("2").gameObject;
                        obj1.SetActive(false);
                    }
                    else
                    {
                        GameObject obj1 = priorRoom.transform.Find("3").gameObject;
                        obj1.SetActive(false);
                    }
                }
            } //현재 방 벽 제거
            
            GameObject room = Instantiate(wallPrefab); //방 생성

            mapRand = Random.Range(0, 6); //맵 디자인 랜덤
            if (mapRand == prior_mapRand)
            {
                mapRand = Random.Range(0, 6);
                prior_mapRand = mapRand;
            }
            else prior_mapRand = mapRand;
            
            priorDir = dir; //다음 방의 이전방향 전환
            if (priorDir == 0)
                priorDir = 2;
            else if (priorDir == 1)
                priorDir = 3;
            else if (priorDir == 2)
                priorDir = 0;

            for (int j = 0; j < 4; j++) //다음 방 벽 제거
            {
                if (j == priorDir)
                {
                    if (j == 0)
                    {
                        GameObject obj1 = room.transform.Find("0").gameObject; // Object의 이름을 찾음. 가장 처음에 나오는 Object를 반환.
                        obj1.SetActive(false);
                    }
                    else if (j == 1)
                    {
                        GameObject obj1 = room.transform.Find("1").gameObject;
                        obj1.SetActive(false);
                    }
                    else if (j == 2)
                    {
                        GameObject obj1 = room.transform.Find("2").gameObject;
                        obj1.SetActive(false);
                    }
                    else
                    {
                        GameObject obj1 = room.transform.Find("3").gameObject;
                        obj1.SetActive(false);
                    }
                }
            } //다음방 벽 제거

            if (dir == 0) //방향이 위일때
            {
                map[y - 1][x] = 2;
                map[y - 2][x] = 1;
                roadY = y - 1;
                roadX = x;
                y -= 2;
                roadRotater = 0;
            } //방, 길 좌표 계산
            else if (dir == 1) //방향이 왼쪽 일때
            {
                map[y][x - 1] = 2;
                map[y][x - 2] = 1;
                roadY = y;
                roadX = x - 1;
                x -= 2;
                roadRotater = 1;
            }
            else if (dir == 2) //방향이 아래쪽 일때
            {
                map[y + 1][x] = 2;
                map[y + 2][x] = 1;
                roadY = y + 1;
                roadX = x;
                y += 2;
                roadRotater = 0;
            }
            else //방향이 오른쪽 일때
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
                room.transform.position = new Vector3(x * 43, y * 43, 0); //방 배치
                room.name = i.ToString();
                GameObject BG = Instantiate(bgPrefab[mapRand]); //배경 배치
                BG.transform.position = new Vector3(x * 43, y * 43, 0);

                if (roadRotater == 0)
                {
                    GameObject vert = Instantiate(vertical);
                    vert.transform.position = new Vector3(roadX * 43, roadY * 43, 0);
                } //길 회전
                else
                {
                    GameObject land = Instantiate(landscape);
                    land.transform.position = new Vector3(roadX * 43, roadY * 43, 0);
                }

                map[x][y] = 1; //배열 설정
                map[roadX][roadY] = 2;
            }
            else
            {
                i -= 1;
                if (dir == 0)
                {
                    roadY = y + 1;
                    y += 2;
                } //초기화
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
                priorRoom = room;
        }
    }
}