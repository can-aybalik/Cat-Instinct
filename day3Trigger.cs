using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class day3Trigger : MonoBehaviour
{
    public AudioManager audioManager;
    public CatMovement catMovement;

    public GameObject[] firstDialogues;

    public bool inNearMen = false;

    public selfTalk selfTalkRain;
    // Start is called before the first frame update
    void Start()
    {
        audioManager.PlaySound(0); //RAIN
        catMovement.canMove = false;
        StartCoroutine(WaitAndPrint(2.0f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Debug.Log("start rain dialog");
        selfTalkRain.startRainDialog = true;
        selfTalkRain.openAutomatically = true;
    }
}
