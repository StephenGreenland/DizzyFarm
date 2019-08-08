using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinFence : MonoBehaviour
{
    public int count;
    public GameObject fence;
    public int gridSpace;

    // Start is called before the first frame update
    void Start()
    {
       Vector3 newPos;
        

            for (int j = 0; j < 65; j+= gridSpace)
            {
                for (int k = 0; k < 65; k+= gridSpace)
                {
                    newPos = new Vector3(transform.position.x + j, 0, transform.position.z + k);

                    if (PerlinSaysOkay(newPos))
                    {
                        
                        Instantiate(fence, newPos, Random.Range(0,2) <1 ? Quaternion.Euler(-90,0,0): Quaternion.Euler(-90,0,90));
                        
                    }
                    
                }
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private bool PerlinSaysOkay(Vector3 newPos)
    {
        //how quickly perlin noise changes
        float freq = 8f;

        //Check current position
        float howSureIsPerlin = Mathf.PerlinNoise(newPos.x / 100 * freq, newPos.z / 100 * freq);

        if (.6 <= howSureIsPerlin)
            return true;
        else
            return false;
    }
}
