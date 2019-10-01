using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int xMapSize = 50;
    public int zMapSize = 50;
    public Vector3[] fullMap;

    void Awake()
    {
        fullMap = new Vector3[(xMapSize + 1) * (zMapSize + 1)];

        for (int z = 0; z <= zMapSize; z++)
        {
            for (int x = 0; x <= xMapSize; x++)
            {
                float y = Mathf.PerlinNoise(x * .3f, z * .3f) * 2f;
                fullMap[x+xMapSize*z] = new Vector3(x, y, z);
            }
        }
    }
}
