using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgGenerator : MonoBehaviour
{
    public GameObject bgPrefab;
    public GameObject roadPrefab;
    public int n;
    int[][] map;
    void Start ()
    {
        map = new int[9][]; //¸Ê 9 * 9 Å©±âÀÇ 2Â÷¿ø ¹è¿­ »ý¼º
        for(int i = 0; i < 9; i++)
        {
            map[i] = new int[9];
            for(int j = 0; j < 9; j++)
                map[i][j] = 0;
        }
        map[4][4] = 1; //0Àº ºó °÷, 1Àº ¹æ, 2´Â ±æ
        mapArrange2();
    }

    
    void mapArrange2()
    {
        int y = 4, x = 4;
        int roadY, roadX;
        int rotater;
        for(int i = 0; i < n; i++)
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
            GameObject G = Instantiate(bgPrefab);
            G.transform.position = new Vector3(x * 42, y * 42, 0);
            GameObject R = Instantiate(roadPrefab);
            R.transform.position = new Vector3(roadX * 42, roadY * 42, 0);
            if (rotater == 1)
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
    }

    void mapArrange()
    {
        int mapX;
        int mapY;
        for (int i = 0; i < 5; i++) //mapX, mapY°¡ Â¦¼ö
        {
            mapX = Random.Range(0, 5);
            mapX *= 2;
            mapY = Random.Range(0, 5);
            mapY *= 2;
            if (map[mapX][mapY] == 0)
                map[mapX][mapY] = 1;
            else
            {
                i--;
                continue;
            }

            GameObject G = Instantiate(bgPrefab);
            G.transform.position = new Vector3(mapX * 42, mapY * 42, 0);
        }
    }

    /*public int maps; //·£´ý »ý¼º È½¼ö
   public float mapXlimit;
   public float mapYlimit;
   float mapX; //¸Ê xÁÂÇ¥
   float mapY; //¸Ê yÁÂÇ¥
   float[] mapXhistory;
   float[] mapYhistory;
   void Start()
   {
       maps = 15;
       maplimit = 9;
       mapXhistory = new float[maps];
       mapYhistory = new float[maps];
       mapArrange();
   }

   void mapArrange() //¸Ê ¹è¿­
   {
       for (int i = 0; i < maps; i++)
       {
           int check = 0;
           int mapXmaker = { Random.Range(1, maplimit * 3) } % 10 + 1;
           int mapYmaker = { Random.Range(1, maplimit * 3) } % 10 + 1;
           mapX = mapXmaker * 42
           mapY = mapYmaker * 42
           mapXhistory[i] = mapX;
           mapYhistory[i] = mapY;

           for(int j = 0; j < i; j++)
           {
               if(Mathf.Abs(mapX - mapXhistory[j]) <= 50 && Mathf.Abs(mapY - mapYhistory[j]) <= 50)
               {
                   check = 1;
                   break;
               }

           }

           if (check == 1)
           {
               i--;
               continue;
           }
           GameObject G = Instantiate(bgPrefab);            
           G.transform.position = new Vector3(mapX, mapY, i);
       }

   }*/
}