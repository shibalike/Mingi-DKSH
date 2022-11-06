using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgGenerator : MonoBehaviour
{
    public GameObject bgPrefab;
    public int maps; //·£´ý »ý¼º È½¼ö
    public float mapXlimit;
    public float mapYlimit;
    float mapX; //¸Ê xÁÂÇ¥
    float mapY; //¸Ê yÁÂÇ¥
    float[] mapXhistory;
    float[] mapYhistory;
    void Start()
    {
        maps = 15;
        mapXlimit = 400;
        mapYlimit = 400;
        mapXhistory = new float[maps];
        mapYhistory = new float[maps];
        mapArrange();
    }
 
    void mapArrange() //¸Ê ¹è¿­
    {
        for (int i = 0; i < maps; i++)
        {
            int check = 0;
            mapX = Random.Range(-1 * mapXlimit, mapXlimit);
            mapY = Random.Range(-1 * mapYlimit, mapYlimit);
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

    }
}
