using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DreamTalk : MonoBehaviour
{

    public AudioManager audioManager; //ÇOK SIKILDIM BAYILACAM
    public GameObject[] dialogues;
    int counter = 0;
    public CatMovement catMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (counter == 0) //Space'i kapat
            {
                catMovement.canMove = false;
                catMovement.anim.SetBool("move", false);
                catMovement.catWalking.Stop();
                //space.GetComponent<Animator>().SetBool("close", true);
                //space.GetComponent<Animator>().SetBool("again", false);
            }

            if (counter < dialogues.Length) //Iteration
            {
                audioManager.PlayDreamSound(counter);
                dialogues[counter].SetActive(true); //Önce aç

                if (counter > 0)
                {
                    dialogues[counter - 1].GetComponent<Animator>().SetBool("close", true); //Varsa eskisini kapat
                    dialogues[counter - 1].GetComponent<Animator>().SetBool("again", false); //Varsa eskisini kapat

                }

                counter++;
            }
            else
            {
                //selfTalkSound.Play();
                dialogues[counter - 1].GetComponent<Animator>().SetBool("close", true); //Sonuncuyu kapat
                dialogues[counter - 1].GetComponent<Animator>().SetBool("again", false); //Varsa eskisini kapat
                catMovement.canMove = true;
                //firstTimeDoor = false;

                //DAY 2
                SceneManager.LoadScene(2);

            }

        }
    }

}

