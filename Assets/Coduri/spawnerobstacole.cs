using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerobstacole : MonoBehaviour
{
    public Transform player;
    public GameObject[] tiles;
    public float spawnpunct = 0;
    public float marimetile = 30;
    public float marimetile_orizontal = 6;
    public int numardetile = 5;
    private List<GameObject> activeTiles = new List<GameObject>();

    private int[] variabiletiles = { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 4, 4, 4,4, 5, 5, 5, 6,6,6, 7, 7, 8, 8, 9, 9, 10, 11, 12,12,12,12,12,13,13,13,13,13,14,14,14,14,14,15,14,15,15,15,15,16,16,16};
    public int valorivar;
    void Start()
    {
        for (int i = 0; i < numardetile; i++)
        {
            if (i == 0)
            {
                Spawntile(0);
            }

            else
            {
                Spawntile(0);
            }
        }
    }
    void Update()
    {
        valorivar = variabiletiles[Random.Range(0, variabiletiles.Length)];
        if (player.position.z - 20 > spawnpunct - (numardetile * marimetile))
        {
            Spawntile(valorivar);
            Delete();
        }
    }


    void Spawntile(int tileindex)
    {
        if (tileindex == 13 || tileindex==12)
        {
            GameObject obs = Instantiate(tiles[tileindex], transform.forward * spawnpunct , transform.rotation);
            var poz = player.transform.position.z;
            LeanTween.moveLocalZ(obs, poz - 20f, (int)poz);
            activeTiles.Add(obs);
            spawnpunct = spawnpunct + marimetile;
        }
        else
        {
            GameObject obs = Instantiate(tiles[tileindex], transform.forward * spawnpunct + new Vector3(0, -70, 0), transform.rotation);
            LeanTween.moveLocalY(obs, 0f, 1.2f);
            activeTiles.Add(obs);
            spawnpunct = spawnpunct + marimetile;
        }
    }

    public void Delete()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
