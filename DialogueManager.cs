using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    private IEnumerator coroutine;
    public AudioSource goodTalk;
    public AudioSource badTalk;
    public AudioSource doorClose;

    public GameObject[] dialogues;

    public GameObject blackScene;
    public GameObject day1;

    public GameObject[] disables;

    public GameObject Cat;

    int counter = 0;

    bool firstTime = true;
    bool startDialogue = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndPrint(5.0f));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && startDialogue)
        {

            if(counter < 6)
            {
                dialogues[counter + 1].SetActive(true);

                if (dialogues[counter + 1].tag == "Person")
                    goodTalk.Play();
                else
                    badTalk.Play();

                if (counter > 0)
                {
                    dialogues[counter - 1].GetComponent<Animator>().SetBool("close", true);
                }
                counter = counter + 1;
            }

            else
            {
                if (firstTime)
                {
                    doorClose.Play();
                    blackScene.SetActive(true);
                    StartCoroutine(WaitAndPrint2(3.0f));
                    firstTime = false;
                }
                  
            }


            
        }
    }


    private IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        dialogues[counter].SetActive(true);
        goodTalk.Play();
        startDialogue = true;
    }

    private IEnumerator WaitAndPrint2(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        blackScene.SetActive(false);
        day1.SetActive(true);
        disableObjects(disables);
        StartCoroutine(WaitAndPrint3(3.0f));
    }

    private IEnumerator WaitAndPrint3(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        day1.SetActive(false);
        Cat.SetActive(true);
    }

    void disableObjects(GameObject[] objects)
    {
        for (int i = 0; i < objects.Length; i++)
            objects[i].SetActive(false);
    }
}
