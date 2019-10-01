using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDeformer : MonoBehaviour
{
    Mesh mesh;

    public Map map;
    public int xSize = 21;
    public int zSize = 21;
    private Vector3[] vertices;
    private int[] trangles;

    void Start()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        trangles = new int[xSize * zSize * 6];

        CreateShapes();

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        Map();
    }

    private void CreateShapes()
    {
        for(int z = 0; z <= zSize; z++)
        {
            for(int x = 0; x <= xSize; x++)
            {
                vertices[x+xSize*z] = new Vector3(x, 0, z);
            }
        }

        int tris = 0;
        for (int z = 0; z < zSize-1; z++)
        {
            for (int x = 0; x < xSize-1; x++)
            {
                trangles[tris + 0] = x+xSize*z;
                trangles[tris + 1] = x + xSize * (z+1);
                trangles[tris + 2] = x + xSize * z + 1;
                trangles[tris + 3] = x + xSize * z + 1;
                trangles[tris + 4] = x + xSize * (z + 1);
                trangles[tris + 5] = (x+1) + xSize * (z + 1);
                tris += 6;
            }
        }
    }

    public void Update()
    {
        UpdateShape();
    }
    
    private void Map()
    {
        int x = Mathf.RoundToInt(transform.position.x);
        int z = Mathf.RoundToInt(transform.position.z);
        for(int vz = 0; vz < zSize; vz++)
        {
            for (int vx = 0; vx < xSize; vx++)
            {
                vertices[vx+xSize*vz].y = map.fullMap[(vx+x)+map.xMapSize*(vz+z)].y;
            }
        }
    }

    private void UpdateShape()
    {
        mesh.Clear();

        Map();

        mesh.vertices = vertices;
        mesh.triangles = trangles;

        mesh.RecalculateNormals();
    }

    private void OnDrawGizmos()
    {
        if (map.fullMap == null)
            return;

        for(int i = 0; i < map.fullMap.Length; i++)
        {
            Gizmos.DrawSphere(map.fullMap[i], .1f);
        }
    }
}
