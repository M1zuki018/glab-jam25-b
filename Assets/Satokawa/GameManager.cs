using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Timer timer;
    public KeyInputCounter counter;
    // Start is called before the first frame update
    void Start()
    {
        counter.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartInputKey()
    {
        timer.TimeStart(15);
        counter.enabled = true;
        counter.ResetCount();
    }
}
