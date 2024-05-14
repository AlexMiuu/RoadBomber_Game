using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generaretiles : MonoBehaviour
{
    public GameObject[] tiles;
    public float spawnpunct = 0;
    public float marimetile = 30;
    public float marimetile_orizontal = 6;
    public int numardetile = 5;
    private List<GameObject>activeTiles=new List<GameObject>();
    public int aux = 0;
    private scor scorr;

     public Transform player;

    private int[] valoritunel = { 9,9,9,9,9,9,9,10,10 };
    private int[] valoricamp = { 4, 4, 4, 4, 4, 4, 4,4,3, 3, 3, 3,8,8 };
    private int[] valoritunel_t6 = { 5, 5,6, 6, 6, 7, 7, 7, 8,8 };
    private int[] valorirandom = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 8,8,11,11,11,11,15,15,15,15,15,15,15};
    private int[] tilemarevalori = { 12, 12, 12, 12, 12, 13, 13, 13, 13, 13, 13, 13, 14, 14 };
    private int[] tilemaresimici = { 15, 15, 15, 15, 0, 0, 2 };
    private int[] first_tile = {4,4,5,5,6,6,7,7,8,8,15,15,15,15 };
    public int valoare;
    public int valoarecamp;
    public int valoare_t6;
    public int valran;
    private int tilemarivalll;
    private int micimaritiles;
    private int first_tileval;
    void Start()
    {


       for(int i=0;i<numardetile;i++)
        {
            if (i == 0)
            {
                Spawntile(0);
                aux = 0;
            }

            else
            {
                Spawntile(0);
                aux = 0;
                Debug.Log(tiles.Length);
            }
        }
    }


    
    void Update()
    {
        valoare = valoritunel[Random.Range(0,valoritunel.Length)];
        valoarecamp= valoricamp[Random.Range(0, valoricamp.Length)];
        valoare_t6 = valoritunel_t6[Random.Range(0, valoritunel_t6.Length)];
        valran = valorirandom[Random.Range(0, valorirandom.Length)];
        tilemarivalll = tilemarevalori[Random.Range(0, tilemarevalori.Length)];
        micimaritiles = tilemaresimici[Random.Range(0, tilemaresimici.Length)];
        first_tileval = first_tile[Random.Range(0, first_tile.Length)];
        if (player.position.z - 120 > spawnpunct - (numardetile * marimetile))
        {

            switch(aux)
            {
                case 0:
                    Spawntile(first_tileval);
                    Deletetile();
                    break;
                    
                case 1:
                    Spawntile(2);
                    Deletetile();
                    break;

                case 2:
                    Spawntile(Random.Range(tiles.Length - 12, 2));
                    Deletetile();
                    break;

                case 3:
                    Spawntile(Random.Range(5, tiles.Length - 7));
                    Deletetile();
                    break;

                case 4:
                    Spawntile(valoarecamp);
                    Deletetile();
                    break;
                case 5:
                    Spawntile(Random.Range(0, tiles.Length - 14));
                    Deletetile();
                    break;
                case 6:
                    Spawntile(valoare_t6);
                    Deletetile();
                    break;
                case 7:
                    Spawntile(valran);
                    Deletetile();
                    break;
                case 8:
                    Spawntile(9);
                    Deletetile();
                    break;
                case 9:
                    Spawntile(valoare);
                    Deletetile();
                    break;
                case 10:
                    Spawntile(Random.Range(0, tiles.Length - 8));
                    Deletetile();
                    break;
                case 11:
                    Spawntile(Random.Range(5, 6));
                    Deletetile();
                    break;
                case 12:
                    Spawntile(tilemarivalll);
                    Deletetile();
                    break;
                case 13:
                    Spawntile(tilemarivalll);
                    Deletetile();
                    break;
                case 14:
                    Spawntile(micimaritiles);
                    Deletetile();
                    break;
                case 15:
                    Spawntile(tilemarivalll);
                        Deletetile();
                    break;

            }
        }
         
    }

    public void Spawntile(int tileindex)
    {
        //Vector3 offset = new Vector3(-61, 0, 0);

       /* if (aux == 1)
        {
            GameObject go = Instantiate(tiles[tileindex], transform.forward * spawnpunct, transform.rotation);
            activeTiles.Add(go);
            aux = tileindex;
            spawnpunct = spawnpunct + marimetile_orizontal;
        }
        else
          if (aux == 1)
        {
            GameObject go = Instantiate(tiles[tileindex], transform.forward * spawnpunct, transform.rotation);
            activeTiles.Add(go);
            aux = tileindex;
            spawnpunct = spawnpunct + marimetile_orizontal;
        }
        else
         if (aux == 3)
        {
            GameObject go = Instantiate(tiles[tileindex], Vector3.right * spawnpunct, transform.rotation);
            activeTiles.Add(go);
            aux = tileindex;
            spawnpunct = spawnpunct + marimetile_orizontal;
        }
        else
       */


        {
            GameObject go = Instantiate(tiles[tileindex], transform.forward * spawnpunct+new Vector3(0,-100,0), transform.rotation);
            LeanTween.moveLocalY(go, 0f, 1f);
            activeTiles.Add(go);
            aux = tileindex;
            spawnpunct = spawnpunct + marimetile;
        }
        
    }
    

   /* public void Spawntileright(int tileindex)
    {
 spawnpunct = spawnpunct + marimetile;
        GameObject go = Instantiate(tiles[tileindex], transform.right * spawnpunct, transform.rotation);
        activeTiles.Add(go);
        aux = tileindex;
        spawnpunct = spawnpunct + marimetile;

    }
   */

    public void Deletetile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
