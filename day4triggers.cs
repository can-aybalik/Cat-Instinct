using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class day4triggers : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject foodEaten;
    bool foodBool = true;
    bool foodCheck = false;


    public GameObject shitPooped;
    bool shitBool = true;
    bool shitCheck = false;

    public bool dayFinished = false;


    public AudioSource day4Theme;

    public CatMovement catMovement;

    public selfTalk selfTalk;
    public selfTalk selfTalk2;

    public bool startDialogue = false;
    public bool startLastDialogue = false;

    public GameObject man;
    public GameObject saloon;
    public bool showMan = false;

    public GameObject lastTalkCollider;
    public GameObject goToTvRoom;

    public GameObject surprise;
    public GameObject redCat;

    void Start()
    {
        startDialogue = false;
        startLastDialogue = false;
        selfTalk.isDay4 = true;
        selfTalk2.isDay4 = true;
        day4Theme.PlayDelayed(2.0f);
        catMovement.canMove = false;
        StartCoroutine(WaitAndPrint(2.0f));
    }

    // Update is called once per frame
    void Update()
    {

        if (shitBool)
        {
            if (shitPooped.active)
            {
                shitCheck = true;
                shitBool = false;
            }
        }

        if (foodBool)
        {
            if (foodEaten.active)
            {
                foodCheck = true;
                foodBool = false;
            }
        }

        if(foodCheck && shitCheck)
        {
            dayFinished = true;
            foodCheck = false;
            shitCheck = false;
        }

        if(showMan && saloon.active)
        {
            man.SetActive(true);
            lastTalkCollider.SetActive(true);
            goToTvRoom.GetComponent<BoxCollider2D>().isTrigger = false;
        }

        if (surprise.active)
        {
            redCat.SetActive(true);
        }

        
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        startDialogue = true;
    }
}
