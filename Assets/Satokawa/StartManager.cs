using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach(SoundManager manager in FindObjectsOfType<SoundManager>())
        {
            manager.BGMStop();
        }
        FindAnyObjectByType<SoundManager>().BGMPlay("ƒ^ƒCƒgƒ‹");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
