using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTreesInGame : MonoBehaviour
{
    public Terrain terrain;
    public float lowerWaterLevel = 287f;
    public float upperWaterLevel = 350f;

    public void RemoveTreesUnderWater()
    {
        TerrainData terrainData = terrain.terrainData;
        TreeInstance[] treeInstances = terrainData.treeInstances;
        List<TreeInstance> updatedTreeInstances = new List<TreeInstance>();

        foreach (TreeInstance treeInstance in treeInstances)
        {
            Vector3 treePosition = Vector3.Scale(treeInstance.position, terrainData.size) + terrain.transform.position;

            if (treePosition.y >= lowerWaterLevel && treePosition.y <= upperWaterLevel)
            {
                updatedTreeInstances.Add(treeInstance);
            }
        }

        terrainData.treeInstances = updatedTreeInstances.ToArray();
    }
}
