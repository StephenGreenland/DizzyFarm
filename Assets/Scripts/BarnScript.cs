using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarnScript : MonoBehaviour
{

    public delegate void Chickenhome();
    public static event Chickenhome OnInpen;

    public Slider Chickens;
    

    int score;
    
    // Start is called before the first frame update
    void onEnable()
    {
        score = 0;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (score > 4)
        {

            Debug.Log("you got all da chickens");

        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Chicken")
        {

            print("do the thing!");

            score++;

            Chickens.value = score;

            OnInpen?.Invoke();

            Destroy(other.gameObject);

        }

    }

}
