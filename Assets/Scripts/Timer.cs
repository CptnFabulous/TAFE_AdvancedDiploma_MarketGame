using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float timeLimit;
    float timer;
    public UnityEvent onTimeUp;
    bool timeLimitReached;

    public Image fillMeter;
    public Gradient colourOverTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 1 && timeLimitReached == false)
        {
            timer = 1;
            timeLimitReached = true;
            onTimeUp.Invoke();
        }
        else
        {
            timer += Time.deltaTime / timeLimit;
        }

        fillMeter.fillAmount = timer;
        fillMeter.color = colourOverTime.Evaluate(timer);

    }
}
