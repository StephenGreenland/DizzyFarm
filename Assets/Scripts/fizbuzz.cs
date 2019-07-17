using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fizbuzz : MonoBehaviour
{

   
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 101; i++)
        {
           
            if (i % 3 == 0)
            {

                print("fizz");

            }
               
            if (i % 5 == 0)
            {
                print("Buzz");

            }

            if(i % 5 != 0 && i % 3 != 0)
            {

                Debug.Log(i);

            }

        }

    }




    // Update is called once per frame
    void Update()
    {

    }
}
