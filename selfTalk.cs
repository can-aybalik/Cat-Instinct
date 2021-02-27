using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selfTalk : MonoBehaviour
{

    public CatMovement catMovement;
    public GameObject[] dialogues;
    public GameObject dream;
    int counter = 0;
    public bool firstTimeDoor = true;
    public bool firstTimeFood = true;
    public bool firstTimePoop = true;
    public bool firstTimeBed = true;
    public bool firstTimeMan = true;

    public GameObject space;

    public bool startDoorDialog = false;
    public bool startFoodDialog = false;
    public bool startPoopDialog = false;
    public bool startBedDialog = false;
    public bool startRainDialog = false;
    public bool startManDialog = false;
    public bool openAutomatically = false;
    public bool openAutomatically2 = true;
    public bool openAutomatically3 = true;

    public AudioSource selfTalkSound;

    public AudioManager audioManager;

    public CatStatus catStatus;

    public GameObject redCat;

    public day4triggers day4Triggers;

    public bool isDay4 = false;

    public GameObject blackScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDay4)
        {
            if (day4Triggers.startDialogue) //FIRST RAIN DIALOG
            {
                //Debug.Log("girdi");
                if (Input.GetKeyDown(KeyCode.Space) || openAutomatically2)
                {
                    if (counter == 0) //Space'i kapat
                    {
                        /*
                        catMovement.canMove = false;
                        catMovement.anim.SetBool("move", false);
                        catMovement.catWalking.Stop();
                        space.GetComponent<Animator>().SetBool("close", true);
                        space.GetComponent<Animator>().SetBool("again", false);
                        */
                        openAutomatically = false;
                    }

                    if (counter < dialogues.Length) //Iteration
                    {
                        selfTalkSound.Play();
                        dialogues[counter].SetActive(true); //Önce aç
                        openAutomatically2 = false;

                        if (counter > 0)
                        {
                            dialogues[counter - 1].GetComponent<Animator>().SetBool("close", true); //Varsa eskisini kapat
                            dialogues[counter - 1].GetComponent<Animator>().SetBool("again", false); //Varsa eskisini kapat

                        }

                        counter++;
                    }
                    else
                    {
                        selfTalkSound.Play();
                        dialogues[counter - 1].GetComponent<Animator>().SetBool("close", true); //Sonuncuyu kapat
                        dialogues[counter - 1].GetComponent<Animator>().SetBool("again", false); //Varsa eskisini kapat
                        catMovement.canMove = true;
                        firstTimeDoor = false;
                        day4Triggers.startDialogue = false;
                    }

                }
            }

            else if (day4Triggers.startLastDialogue) //LAST DIALOGUE
            {
                //openAutomatically3 = true;
                catMovement.canMove = false;
                if (Input.GetKeyDown(KeyCode.Space) || openAutomatically3)
                {
                    
                    if (counter == 0) //Space'i kapat
                    {
                        /*
                        catMovement.canMove = false;
                        catMovement.anim.SetBool("move", false);
                        catMovement.catWalking.Stop();
                        */
                        space.GetComponent<Animator>().SetBool("close", true);
                        space.GetComponent<Animator>().SetBool("again", false);
                        
                        //openAutomatically = false;
                        Debug.Log("last");
                        openAutomatically3 = false;
                        
                    }

                    if (counter < dialogues.Length) //Iteration
                    {
                        selfTalkSound.Play();
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
                        selfTalkSound.Play();
                        dialogues[counter - 1].GetComponent<Animator>().SetBool("close", true); //Sonuncuyu kapat
                        dialogues[counter - 1].GetComponent<Animator>().SetBool("again", false); //Varsa eskisini kapat
                        //catMovement.canMove = true;
                        firstTimeDoor = false;
                        day4Triggers.startDialogue = false;
                        blackScreen.SetActive(true);
                        StartCoroutine(WaitAndPrint(6.0f));
                    }

                }
            }

        }


        


        if (startRainDialog) //FIRST RAIN DIALOG
        {

            if (Input.GetKeyDown(KeyCode.Space) || openAutomatically)
            {
                if (counter == 0) //Space'i kapat
                {
                    /*
                    catMovement.canMove = false;
                    catMovement.anim.SetBool("move", false);
                    catMovement.catWalking.Stop();
                    
                    space.GetComponent<Animator>().SetBool("close", true);
                    space.GetComponent<Animator>().SetBool("again", false);
                    */
                    openAutomatically = false;
                }

                if (counter < dialogues.Length) //Iteration
                {
                    selfTalkSound.Play();
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
                    selfTalkSound.Play();
                    dialogues[counter - 1].GetComponent<Animator>().SetBool("close", true); //Sonuncuyu kapat
                    dialogues[counter - 1].GetComponent<Animator>().SetBool("again", false); //Varsa eskisini kapat
                    catMovement.canMove = true;
                    firstTimeDoor = false;
                }

            }
        }

        if(startManDialog && firstTimeMan) //MAN RAIN
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Man dialog");
                if (counter == 0) //Space'i kapat
                {
                    catMovement.canMove = false;
                    catMovement.anim.SetBool("move", false);
                    catMovement.catWalking.Stop();
                    space.GetComponent<Animator>().SetBool("close", true);
                    space.GetComponent<Animator>().SetBool("again", false);
                }

                if (counter < dialogues.Length) //Iteration
                {
                    selfTalkSound.Play();
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
                    selfTalkSound.Play();
                    dialogues[counter - 1].GetComponent<Animator>().SetBool("close", true); //Sonuncuyu kapat
                    dialogues[counter - 1].GetComponent<Animator>().SetBool("again", false); //Varsa eskisini kapat
                    catMovement.canMove = true;
                    firstTimeMan = false;
                    redCat.SetActive(true);
                }

            }

        }




        if (startDoorDialog && firstTimeDoor) //DOOR CASE
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (counter == 0) //Space'i kapat
                {
                    catMovement.canMove = false;
                    catMovement.anim.SetBool("move", false);
                    catMovement.catWalking.Stop();
                    space.GetComponent<Animator>().SetBool("close", true);
                    space.GetComponent<Animator>().SetBool("again", false);
                }

                if(counter < dialogues.Length) //Iteration
                {
                    selfTalkSound.Play();
                    dialogues[counter].SetActive(true); //Önce aç

                    if(counter > 0)
                    {
                        dialogues[counter - 1].GetComponent<Animator>().SetBool("close", true); //Varsa eskisini kapat
                        dialogues[counter - 1].GetComponent<Animator>().SetBool("again", false); //Varsa eskisini kapat

                    }

                    counter++;
                }
                else
                {
                    selfTalkSound.Play();
                    dialogues[counter - 1].GetComponent<Animator>().SetBool("close", true); //Sonuncuyu kapat
                    dialogues[counter - 1].GetComponent<Animator>().SetBool("again", false); //Varsa eskisini kapat
                    catMovement.canMove = true;
                    firstTimeDoor = false;
                }

            }
        }

        else if (startFoodDialog && firstTimeFood) //FOOD CASE
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (counter == 0) //Space'i kapat
                {
                    catMovement.canMove = false;
                    catMovement.anim.SetBool("move", false);
                    catMovement.catWalking.Stop();
                    space.GetComponent<Animator>().SetBool("close", true);
                    space.GetComponent<Animator>().SetBool("again", false);

                }

                if (counter < dialogues.Length) //Iteration
                {
                    Debug.Log("AÇ");
                    //selfTalkSound.Play();
                    dialogues[counter].SetActive(true); //Önce aç
                    audioManager.PlaySound(0);

                    if (counter > 0)
                    {
                        dialogues[counter - 1].GetComponent<Animator>().SetBool("close", true); //Varsa eskisini kapat
                        dialogues[counter - 1].GetComponent<Animator>().SetBool("again", false); //Varsa eskisini kapat

                    }

                    counter++;
                }
                else
                {
                    audioManager.StopSound(0);
                    selfTalkSound.Play();
                    dialogues[counter - 1].GetComponent<Animator>().SetBool("close", true); //Sonuncuyu kapat
                    dialogues[counter - 1].GetComponent<Animator>().SetBool("again", false); //Varsa eskisini kapat
                    catMovement.canMove = true;
                    firstTimeFood = false;
                    Debug.Log("Sonuncu");
                    catStatus.isHungry = false;
                    
                }

            }
        }

        else if (startPoopDialog && firstTimePoop) //POOP CASE
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (counter == 0) //Space'i kapat
                {
                    catMovement.canMove = false;
                    catMovement.anim.SetBool("move", false);
                    catMovement.catWalking.Stop();
                    space.GetComponent<Animator>().SetBool("close", true);
                    space.GetComponent<Animator>().SetBool("again", false);

                }

                if (counter < dialogues.Length) //Iteration
                {
                    Debug.Log("AÇ");
                    //selfTalkSound.Play();
                    dialogues[counter].SetActive(true); //Önce aç
                    audioManager.PlaySound(1);

                    if (counter > 0)
                    {
                        dialogues[counter - 1].GetComponent<Animator>().SetBool("close", true); //Varsa eskisini kapat
                        dialogues[counter - 1].GetComponent<Animator>().SetBool("again", false); //Varsa eskisini kapat

                    }

                    counter++;
                }
                else
                {
                    audioManager.StopSound(0);
                    selfTalkSound.Play();
                    dialogues[counter - 1].GetComponent<Animator>().SetBool("close", true); //Sonuncuyu kapat
                    dialogues[counter - 1].GetComponent<Animator>().SetBool("again", false); //Varsa eskisini kapat
                    catMovement.canMove = true;
                    firstTimePoop = false;
                    Debug.Log("Sonuncu");
                    catStatus.toiletUsed = true;
                    startPoopDialog = false;
                }

            }
        }

        else if (!catStatus.isHungry && catStatus.toiletUsed && !isDay4) //SLEEP CASE
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (counter == 0) //Space'i kapat
                {
                    catMovement.canMove = false;
                    catMovement.anim.SetBool("move", false);
                    catMovement.catWalking.Stop();
                    space.GetComponent<Animator>().SetBool("close", true);
                    space.GetComponent<Animator>().SetBool("again", false);

                }

                if (counter < dialogues.Length) //Iteration
                {
                    Debug.Log("AÇ");
                    selfTalkSound.Play();
                    dialogues[counter].SetActive(true); //Önce aç
                    //audioManager.PlaySound(1);

                    if (counter > 0)
                    {
                        dialogues[counter - 1].GetComponent<Animator>().SetBool("close", true); //Varsa eskisini kapat
                        dialogues[counter - 1].GetComponent<Animator>().SetBool("again", false); //Varsa eskisini kapat

                    }

                    counter++;
                }
                else
                {
                    audioManager.StopSound(0);
                    selfTalkSound.Play();
                    dialogues[counter - 1].GetComponent<Animator>().SetBool("close", true); //Sonuncuyu kapat
                    dialogues[counter - 1].GetComponent<Animator>().SetBool("again", false); //Varsa eskisini kapat
                    //catMovement.canMove = true;
                    catStatus.isHungry = true;
                    catStatus.toiletUsed = false;
                    Debug.Log("Sonuncu");

                    dream.SetActive(true);

                    dream.GetComponent<Animator>().SetBool("fadeStart", true);
                    dream.GetComponent<Animator>().SetBool("fadeEnd", false);

                }

            }
        }



    }
}
