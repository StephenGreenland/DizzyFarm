using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoiseGenerator : MonoBehaviour
{
    //how many objects to spawn
    public int count = 100;
    //placement area (your level) width
    public float x = 100f;
    //placement area (your level) length
    public float z = 100f;
    //How far our objects should stay away from each other
    //If you're using a list of objects, you'd probably wanna make a list
    //of distances in order to make sure they dont overlap without being
    //too far apart
    public float minDistance = 0.5f;

    //One prefab for now, you can make a list later
    public List<GameObject> obsPrefabs;
    //positions we'll be storing
    public List<Vector3> positions = new List<Vector3>();

    void Start()
    {
        //get locs
        PlaceShitRandomly();

        //use locations to move our objs
        for (int x = 0; x < count; x++)
        {
            var newObj = Instantiate(obsPrefabs[Random.Range(0, obsPrefabs.Count)]);
            newObj.transform.position = positions[x];
        }

    }

    void PlaceShitRandomly()
    {
        Vector3 newPos;
        bool nope = false;

        //for loop to go through how many objects we want
        for (int i = 0; i < count; i++)
        {

            do
            {
                //Pick a new random position
                newPos = new Vector3(transform.position.x + (Random.value * x), 0, transform.position.z + (Random.value * z));
                //Check if the position on the perlin noise is good
                nope = !(PerlinSaysOkay(newPos) && CanPlaceThere(newPos));
            } while (nope);

            positions.Add(newPos);
        }
    }

    private bool CanPlaceThere(Vector3 newPos)
    {
        //loop through all positions where we've already decided to place something
        for (int i = 0; i < positions.Count; i++)
        {
            //Debug.Log(obsPrefabs.IndexOf(spawnedObjs[i]));
            //find out our minDist from the list of distances using our object
            
            //float tempDist = spawnedObjs[i].GetComponent<ScriptName>().minDistance

            //Check if new point is too close
            if (Vector3.Distance(positions[i], newPos) < minDistance)
            {
                return false;
            }
        }
        return true;
    }

    private bool PerlinSaysOkay(Vector3 newPos)
    {
        //how quickly perlin noise changes
        float freq = 8f;

        //Check current position
        float howSureIsPerlin = Mathf.PerlinNoise(newPos.x / x * freq, newPos.z / z * freq);

        if (Random.value <= howSureIsPerlin)
            return true;
        else
            return false;
    }
}
