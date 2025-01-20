using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTreesInGame : MonoBehaviour
{
    public Terrain terrain;
    public float lowerWaterLevel = 287f;
    public float upperWaterLevel = 350f;

    // Array of prototype indices that correspond to stone types
    public int[] stonePrototypeIndices;

    public void RemoveTreesUnderWater()
    {
        if (terrain == null)
        {
            Debug.LogError("Terrain is not assigned!");
            return;
        }

        TerrainData terrainData = terrain.terrainData;
        TreeInstance[] treeInstances = terrainData.treeInstances;
        List<TreeInstance> updatedTreeInstances = new List<TreeInstance>();

        foreach (TreeInstance treeInstance in treeInstances)
        {
            // Calculate the world position of the tree
            Vector3 treePosition = Vector3.Scale(treeInstance.position, terrainData.size) + terrain.transform.position;

            // Check if this tree's prototype index matches a "stone" index
            bool isStone = System.Array.Exists(stonePrototypeIndices, index => index == treeInstance.prototypeIndex);

            // Only remove trees below the lowerWaterLevel and not stones
            if (treePosition.y < lowerWaterLevel)
            {
                // If it's a tree and below the water level, remove it
                continue;
            }
            if(treePosition.y > upperWaterLevel && !isStone)
            {
                continue;
            }
            // If the tree is either above the upperWaterLevel or a stone, keep it
            updatedTreeInstances.Add(treeInstance);
        }

        // Update the terrain with the modified tree instances
        terrainData.treeInstances = updatedTreeInstances.ToArray();
        Debug.Log("Tree removal completed!");
    }
}
