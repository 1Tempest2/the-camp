using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveGrassInGame : MonoBehaviour
{
    public Terrain terrain;
    public float lowerWaterLevel = 287f;
    public float upperWaterLevel = 350f;

    public void RemoveGrassUnderWater()
    {
        TerrainData terrainData = terrain.terrainData;

        // Get terrain size
        Vector3 terrainSize = terrainData.size;
        Vector3 terrainPosition = terrain.transform.position;

        // Iterate through each detail layer (grass type)
        for (int layer = 0; layer < terrainData.detailPrototypes.Length; layer++)
        {
            int[,] detailLayer = terrainData.GetDetailLayer(0, 0, terrainData.detailWidth, terrainData.detailHeight, layer);

            for (int x = 0; x < terrainData.detailWidth; x++)
            {
                for (int y = 0; y < terrainData.detailHeight; y++)
                {
                    // Calculate the world position of this grass cell
                    float worldX = terrainPosition.x + ((float)x / terrainData.detailWidth) * terrainSize.x;
                    float worldZ = terrainPosition.z + ((float)y / terrainData.detailHeight) * terrainSize.z;

                    // Get the height at this position
                    float height = terrain.SampleHeight(new Vector3(worldX, 0, worldZ));

                    // If the height is outside the specified range, remove the grass
                    if (height < lowerWaterLevel || height > upperWaterLevel)
                    {
                        detailLayer[y, x] = 0; // Remove grass
                    }
                }
            }

            // Apply the updated detail layer back to the terrain
            terrainData.SetDetailLayer(0, 0, layer, detailLayer);
        }
    }
}
