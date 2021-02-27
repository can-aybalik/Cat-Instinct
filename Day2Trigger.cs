using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Day2Trigger : MonoBehaviour
{

    public CatMovement catMovement;

    bool firstTimeKnock = true;
    public GameObject tvRoom;

    public GameObject doorDialog;
    bool lockFoodAndToilet = true;

    public activeObjects toiletCollider;
    public activeObjects foodColider;


    public AudioManager audioManager;

    public GameObject scaryPoopTrigger;
    bool firstTimePoop = true;

    //BLOOD TRIGGERS
    public bool bloodTrigger = false;
    public GameObject bloods;
    public GameObject bedRoomLocked1;
    public GameObject bedRoomLocked2;
    public GameObject bedRoom;
    bool firstTimeBlood = true;
    bool doorTrigger = true;

    //DITHERED CAT
    public GameObject[] ditheredCats;

    //CAT TRIGGERS
    bool startCats = false;

    //DAY 3 START
    public GameObject blackScreen;
    public GameObject day3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        /*

        if (lockFoodAndToilet)
        {
            foodColider.enabled = false;
            toiletCollider.enabled = false;
        }

        else
        {
            foodColider.enabled = true;
            toiletCollider.enabled = true;
        }

        if(lockFoodAndToilet && doorDialog.active)
        {
            lockFoodAndToilet = false;
        }

        */

        if (firstTimeKnock && tvRoom.active)
        {
            audioManager.PlaySound(3);
            firstTimeKnock = false;
        }



        if (firstTimePoop)
        {
            if (scaryPoopTrigger.active)
            {
                audioManager.PlaySound(2);
                firstTimePoop = false;
            }
        }

        if (bloodTrigger && bedRoom.active && firstTimeBlood)
        {
            bloods.SetActive(true);
            bedRoomLocked1.SetActive(false);
            bedRoomLocked2.SetActive(true);
            bloodTrigger = false;
            firstTimeBlood = false;
            startCats = true;
            audioManager.PlaySound(4);
        }

        if (doorTrigger)
        {
            if (doorDialog.active)
            {
                bloodTrigger = true;
                doorTrigger = false;
            }
        }

        if (startCats)
        {
            catMovement.canMove = false;
            catMovement.anim.SetBool("move", false);
            catMovement.catWalking.Stop();
            StartCoroutine(WaitAndPrint(3.0f, 0));
            StartCoroutine(WaitAndPrint2(4.0f));
            StartCoroutine(WaitAndPrint3(6.0f));
            StartCoroutine(WaitAndPrint4(8.0f));
        }
        

    }

    private IEnumerator WaitAndPrint(float waitTime, int index)
    {
        yield return new WaitForSeconds(waitTime);
        //ditheredCats[index].SetActive(true);
        //audioManager.PlaySound(5);
    }

    private IEnumerator WaitAndPrint2(float waitTime) //BLACK SCREEN
    {
        yield return new WaitForSeconds(waitTime);
        ditheredCats[0].SetActive(false);
        //audioManager.StopSound(4);
        blackScreen.SetActive(true);

    }

    private IEnumerator WaitAndPrint3(float waitTime) //DAY 3
    {
        yield return new WaitForSeconds(waitTime);
        //blackScreen.SetActive(false);
        day3.SetActive(true);
        //audioManager.PlaySound(6);
    }

    private IEnumerator WaitAndPrint4(float waitTime) //DAY 3
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(3);
    }
}
