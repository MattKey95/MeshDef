using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject tile;
    public int xSize = 5;
    public int zSize = 5;
    public float ChangeCoolDown = 5;

    float timeElapsed = 0;
    GameObject[] grid;
    // Start is called before the first frame update
    void Start()
    {
        grid = new GameObject[(xSize+1) * (zSize+1)];

        for(int z = 0; z < zSize; z++)
        {
            for(int x = 0; x < xSize; x++)
            {
                grid[x + xSize * z] = Instantiate(tile, new Vector3(x*20, 0 ,z*20), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed >= ChangeCoolDown)
        {
            if (!grid.Any(o => o != null))
                return;

            timeElapsed = 0;

            var x = Random.Range(0, xSize-1);
            var z = Random.Range(0, zSize-1);

            while(grid[x + xSize * z] == null)
            {
                x = Random.Range(0, xSize-1);
                z = Random.Range(0, zSize-1);
            }

            var deadTile = grid[x + xSize * z];

            var newX = Random.Range(0, 2);
            var newZ = Random.Range(0, 2);

            if (newX + newZ == 0)
                newX++;

            if (newX + newZ == 2)
                newX--;

            grid[(x + newX) + xSize * (z + newZ)].GetComponent<Tile>().Move(deadTile.transform.position);

            Destroy(deadTile);
        }
    }
}
