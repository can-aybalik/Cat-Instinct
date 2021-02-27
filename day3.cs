using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class day3 : MonoBehaviour
{
    public AudioSource audio;
    bool firstTime = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(firstTime && this.gameObject.active)
        {
            audio.Play();
            firstTime = false;
        }
    }
}
