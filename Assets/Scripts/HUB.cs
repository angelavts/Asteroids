using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<sumary>
/// HUB
///</sumary>
public class HUB : MonoBehaviour
{
    [SerializeField]
    Text scoreText;
    float seconds;
    bool running;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        seconds = 0;
        scoreText.text = "0";
        running = true;
        
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if(running){
            seconds+=Time.deltaTime;
            scoreText.text = ((int)seconds).ToString();
        }       
    }

    /// <summary>
    /// Stop game timer
    /// </summary>
    public void StopGameTimer()
    {
        running = false;
    }
}
