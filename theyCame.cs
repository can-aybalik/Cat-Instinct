using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theyCame : MonoBehaviour
{
    bool firstTime = true;
    public day4triggers day4Triggers;
    public AudioSource doorOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.active && day4Triggers.dayFinished && firstTime)
        {
            Debug.Log("GELDİLER");
            doorOpen.Play();
            day4Triggers.showMan = true;
            firstTime = false;
        }
    }
}
