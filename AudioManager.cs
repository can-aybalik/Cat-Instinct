using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource[] sounds;
    public AudioSource[] dreamSounds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(int index)
    {
        sounds[index].Play();
    }

    public void StopSound(int index)
    {
        sounds[index].Stop();
    }

    public void PlayDreamSound(int index)
    {
        dreamSounds[index].Play();
    }

    public void StopDreamSound(int index)
    {
        dreamSounds[index].Stop();
    }
    
}
