using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarnScript : MonoBehaviour
{

    public delegate void Chickenhome();
    public static event Chickenhome OnInpen;

    public Text Score;
    public Text timer;


    
    int score;
    private float timeLeft;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
        score = 0;
        timeLeft = 80f;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        

        
        timeLeft = timeLeft - Time.deltaTime;

        if (timeLeft < 0)
        {
            PlayerPrefs.SetInt("score", score);

            SceneManager.LoadScene(1);
            
        }
        timer.text = timeLeft.ToString();


    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Animal")
        {

            print("do the thing!");

            score++;
            
            Score.text = score.ToString();

            OnInpen?.Invoke();

            Destroy(other.gameObject);

        }

    }

}
