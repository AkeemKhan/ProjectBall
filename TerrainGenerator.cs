using UnityEngine;
using System.Collections;

public class TerrainGenerator : MonoBehaviour {

    private Terrain terrain;
    private TerrainData terrainData;
    public float strength;
    public int range;

    void Awake()
    {
        terrain = transform.GetComponent<Terrain>();
        terrainData = transform.GetComponent<Terrain>().terrainData;
        RaiseTerrain();
        Smooth();
    }

	// Use this for initialization
	void Start () {
        int t = 9;
        Debug.Log(t/2);
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void RaiseTerrain()
    {
        int heightMapWidth = terrainData.heightmapWidth;
        int heightMapHeight = terrainData.heightmapHeight;
        float[,] heights = terrainData.GetHeights(0, 0, heightMapWidth, heightMapHeight);

        System.Random rn = new System.Random();
        int randX = rn.Next(0, heightMapWidth);
        int randZ = rn.Next(0, heightMapHeight);

        float[,] modifiedHeights = new float[1, 1];
        float y = strength;


        modifiedHeights[0, 0] = y;
        //modifiedHeights[100, 100] = y;
        heights[randX, randZ] = y;
        terrainData.SetHeights(0, 0, heights);

       
        //for (int x = 1; x < terrain.terrainData.heightmapWidth; x++)
        //{
        //    for (int z = 0; z < terrain.terrainData.heightmapHeight; z++)
        //    {
        //        Debug.Log("X "+x+" Z "+z);
        //        //Get the distance
        //        //X
        //        int theX = randX - x;
        //        //Z
        //        int theZ = randZ - z;
        //        //X+Z
        //        int distance = Pos(theX) + Pos(theZ);
        //        //Raise by 
        //        if(range-distance > 0)
        //        {
        //            modifiedHeights = new float[1, 1];
        //            y = strength * (range - distance);
        //            modifiedHeights[0, 0] = y;
        //            heights[x, z] = y;
        //            terrainData.SetHeights(x, z, modifiedHeights);
        //        }


        //    }
        //}
            


        



    }

    public int Pos(int num)
    {
        if (num >= 0)
            return num;
        else
            return 0 - num;
    }

    private void Smooth()
    {

        float[,] height = terrain.terrainData.GetHeights(0, 0, terrain.terrainData.heightmapWidth,
                                          terrain.terrainData.heightmapHeight);
        float k = 0.5f;
        /* Rows, left to right */
        for (int x = 1; x < terrain.terrainData.heightmapWidth; x++)
            for (int z = 0; z < terrain.terrainData.heightmapHeight; z++)
                height[x, z] = height[x - 1, z] * (1 - k) +
                          height[x, z] * k;

        /* Rows, right to left*/
        for (int x = terrain.terrainData.heightmapWidth - 2; x < -1; x--)
            for (int z = 0; z < terrain.terrainData.heightmapHeight; z++)
                height[x, z] = height[x + 1, z] * (1 - k) +
                          height[x, z] * k;

        /* Columns, bottom to top */
        for (int x = 0; x < terrain.terrainData.heightmapWidth; x++)
            for (int z = 1; z < terrain.terrainData.heightmapHeight; z++)
                height[x, z] = height[x, z - 1] * (1 - k) +
                          height[x, z] * k;

        /* Columns, top to bottom */
        for (int x = 0; x < terrain.terrainData.heightmapWidth; x++)
            for (int z = terrain.terrainData.heightmapHeight; z < -1; z--)
                height[x, z] = height[x, z + 1] * (1 - k) +
                          height[x, z] * k;

        terrain.terrainData.SetHeights(0, 0, height);
    }

    public void SmoothTest()
    {
        //Get the distance

        //Raise by strength/distance
    }
}
