using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public AudioSource playSound;
    public AudioSource quitSound;
    public AudioSource proceedSound;
    bool onPlay = true;
    bool isProceeded = false;

    public GameObject playOutline;
    public GameObject quitOutline;

    public Animator fadeStart;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && onPlay && !isProceeded)
        {
            QuitSound();
            playOutline.SetActive(false);
            quitOutline.SetActive(true);
            onPlay = false;
        }

        else if(Input.GetKeyDown(KeyCode.W) && !onPlay && !isProceeded)
        {
            PlaySound();
            playOutline.SetActive(true);
            quitOutline.SetActive(false);
            onPlay = true;
        }

        else if(Input.GetKeyDown(KeyCode.Space) && onPlay && !isProceeded)
        {
            fadeStart.SetBool("fadeStart", true);
            isProceeded = true;
            ProceedSound();
            StartCoroutine(WaitAndPrint(2.0f));
            
        }
        
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(1);
    }

    void PlaySound()
    {
        playSound.Play();
        quitSound.Stop();
    }

    void QuitSound()
    {
        playSound.Stop();
        quitSound.Play();
    }

    void ProceedSound()
    {
        proceedSound.Play();
        playSound.Stop();
        quitSound.Stop();
    }
}
