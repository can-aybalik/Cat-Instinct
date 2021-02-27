using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatCollision : MonoBehaviour
{
    public GameObject saloon;
    public GameObject kitchen;
    public GameObject tvRoom;
    public GameObject space;
    public GameObject bedRoom;
    public GameObject toilet;

    public GameObject hungryCase;
    public GameObject toiletCase;

    public AudioSource enterSpace;
    public AudioSource exitSpace;

    public AudioSource doorTransition;

    bool doorInteract = false;
    bool foodInteract = false;

    public selfTalk selfTalk;
    public selfTalk selfTalkDoor;
    public selfTalk selfTalkFood;
    public selfTalk selfTalkPoop;
    public selfTalk selfTalkBed;
    public selfTalk selfTalkRain;
    public selfTalk selfTalkMan;

    public CatStatus catStatus;

    public day3Trigger day3Trigger;

    public AudioManager audioManager;
    public GameObject largeMap;
    public GameObject blackScreen;
    public GameObject[] toDisactive;
    public GameObject camera;
    public GameObject day4;


    public CatMovement catMovement;
    public day4triggers day4Triggers;

    public GameObject rainTalk;
    // Start is called before the first frame update
    void Start()
    {
        space.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //space.transform.rotation.y
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "goToKitchen")
        {
            doorTransition.Play();
            saloon.SetActive(false);
            kitchen.SetActive(true);
            this.gameObject.transform.position = new Vector2(-5.82f, 0.21f);
        }

        else if(other.tag == "lastTalk")
        {
            space.GetComponentInChildren<Animator>().SetBool("again", true);
            space.GetComponentInChildren<Animator>().SetBool("close", false);
            rainTalk.SetActive(true);
            catMovement.canMove = false;
            catMovement.catWalking.Stop();
            catMovement.anim.SetBool("move", false);
            catMovement.catRb.velocity = Vector3.zero;
            day4Triggers.startLastDialogue = true;
            
        }

        else if(other.tag == "goToSaloon")
        {
            doorTransition.Play();
            saloon.SetActive(true);
            kitchen.SetActive(false);
            this.gameObject.transform.position = new Vector2(5.68f, 0.21f);
        }

        else if (other.tag == "goToTvRoom")
        {
            doorTransition.Play();
            saloon.SetActive(false);
            tvRoom.SetActive(true);
            this.gameObject.transform.position = new Vector2(5.68f, -2.23f);
        }

        else if (other.tag == "goToSaloonFromTvRoom")
        {
            doorTransition.Play();
            saloon.SetActive(true);
            tvRoom.SetActive(false);
            this.gameObject.transform.position = new Vector2(-6.0f, -2.23f);
        }

        else if(other.tag == "goToBedRoom")
        {
            hungryCase.SetActive(false);
            toiletCase.SetActive(false);
            doorTransition.Play();
            tvRoom.SetActive(false);
            bedRoom.SetActive(true);
            this.gameObject.transform.position = new Vector2(0.36f, 1.30f);
        }
        
        else if(other.tag == "goToTvRoomFromBedRoom")
        {
            doorTransition.Play();
            tvRoom.SetActive(true);
            bedRoom.SetActive(false);
            this.gameObject.transform.position = new Vector2(0.36f, -3.31f);
        }

        else if(other.tag == "goToToilet")
        {
            doorTransition.Play();
            tvRoom.SetActive(false);
            toilet.SetActive(true);
            this.gameObject.transform.position = new Vector2(6.0f, 0.3f);
        }

        else if(other.tag == "goToTvRoomFromToilet")
        {
            doorTransition.Play();
            tvRoom.SetActive(true);
            toilet.SetActive(false); ;
            this.gameObject.transform.position = new Vector2(-5.9f, 0.5f);
        }

        else if(other.tag == "door")
        {
            selfTalk = selfTalkDoor;
            if (selfTalk.firstTimeDoor)
            {
                if (!space.active)
                    space.SetActive(true);
                else
                {
                    space.GetComponentInChildren<Animator>().SetBool("again", true);
                    space.GetComponentInChildren<Animator>().SetBool("close", false);
                }

                enterSpace.Play();
                exitSpace.Stop();
                selfTalk.startDoorDialog = true;
            }
        }

        else if(other.tag == "food")
        {
            selfTalk = selfTalkFood;
            if (selfTalk.firstTimeFood) //SPACE AÇ
            {

                if (!space.active)
                    space.SetActive(true);
                else
                {
                    space.GetComponentInChildren<Animator>().SetBool("again", true);
                    space.GetComponentInChildren<Animator>().SetBool("close", false);
                }

                enterSpace.Play();
                exitSpace.Stop();
                selfTalk.startFoodDialog = true;
            }
        }

        else if (other.tag == "poop")
        {
            selfTalk = selfTalkPoop;
            if (selfTalk.firstTimePoop) //SPACE AÇ
            {

                if (!space.active)
                    space.SetActive(true);
                else
                {
                    space.GetComponentInChildren<Animator>().SetBool("again", true);
                    space.GetComponentInChildren<Animator>().SetBool("close", false);
                }

                enterSpace.Play();
                exitSpace.Stop();
                selfTalk.startPoopDialog = true;
            }
        }

        else if (other.tag == "rain")
        {
            Debug.Log("GİRDİ");
            selfTalk = selfTalkMan;
            if (selfTalk.firstTimeMan) //SPACE AÇ
            {

                if (!space.active)
                    space.SetActive(true);
                else
                {
                    space.GetComponentInChildren<Animator>().SetBool("again", true);
                    space.GetComponentInChildren<Animator>().SetBool("close", false);
                }

                enterSpace.Play();
                exitSpace.Stop();
                selfTalk.startManDialog = true;
            }
        }

        else if(other.tag == "bed")
        {

            if (catStatus.isHungry)
            {
                Debug.Log("BURAYA GİRME"); //GİRMESENE LAN
                if (!hungryCase.active)
                    hungryCase.SetActive(true);
                else
                {
                    hungryCase.GetComponentInChildren<Animator>().SetBool("again", true);
                    hungryCase.GetComponentInChildren<Animator>().SetBool("close", false);
                }
                enterSpace.Play();
                exitSpace.Stop();
            }

            else if (!catStatus.toiletUsed)
            {
                if (!toiletCase.active)
                    toiletCase.SetActive(true);
                else
                {
                    toiletCase.GetComponentInChildren<Animator>().SetBool("again", true);
                    toiletCase.GetComponentInChildren<Animator>().SetBool("close", false);
                }
                enterSpace.Play();
                exitSpace.Stop();
            }

            else if(!catStatus.isHungry && catStatus.toiletUsed)
            {
                selfTalk = selfTalkBed;
                if (selfTalk.firstTimeBed) //SPACE AÇ
                {

                    if (!space.active)
                        space.SetActive(true);
                    else
                    {
                        space.GetComponentInChildren<Animator>().SetBool("again", true);
                        space.GetComponentInChildren<Animator>().SetBool("close", false);
                    }

                    enterSpace.Play();
                    exitSpace.Stop();
                    selfTalk.startBedDialog = true; //UYKU VAKTİ
                }
            }

            

        }

        else if (other.tag == "redCat")
        {
            print("RED CAT!");
            audioManager.PlaySound(1);
            largeMap.SetActive(false);
            blackScreen.SetActive(true);

            camera.GetComponent<CameraFollow>().enabled = false;
            camera.transform.position = new Vector3(0, 0, -10);
            StartCoroutine(WaitAndPrint(4.0f));
            StartCoroutine(WaitAndPrint2(6.0f));

            for (int i = 0; i < toDisactive.Length; i++)
            {
                toDisactive[i].SetActive(false);
            }

        }


        else if(other.tag == "rainTalk")
        {
            day3Trigger.inNearMen = true;
        }
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        day4.SetActive(true);
    }

    private IEnumerator WaitAndPrint2(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(4);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if(collision.tag == "rain")
        {
            space.GetComponentInChildren<Animator>().SetBool("close", true);
            space.GetComponentInChildren<Animator>().SetBool("again", false);
            enterSpace.Stop();
            exitSpace.Play();
            selfTalk.startManDialog = false;
        }
        
        if(collision.tag == "door")
        {
            if (selfTalk.firstTimeDoor)
            {
                space.GetComponentInChildren<Animator>().SetBool("close", true);
                space.GetComponentInChildren<Animator>().SetBool("again", false);
                enterSpace.Stop();
                exitSpace.Play();
                selfTalk.startDoorDialog = false;
            }
            else //Dialogue is happened,  btw yarı türkçe yarı ingilizce yazıyom amk gta türkçe yama gibi, neyse devam.
            {
                for(int i = 0; i < selfTalk.dialogues.Length; i++)
                {
                    Destroy(selfTalk.dialogues[i]);
                }
            }
        }

        else if(collision.tag == "food")
        {
            if (selfTalk.firstTimeFood)
            {
                space.GetComponentInChildren<Animator>().SetBool("close", true);
                space.GetComponentInChildren<Animator>().SetBool("again", false);
                enterSpace.Stop();
                exitSpace.Play();
                selfTalk.startFoodDialog = false;
            }
            else //
            {
                for (int i = 0; i < selfTalk.dialogues.Length; i++)
                {
                    Destroy(selfTalk.dialogues[i]);
                }
            }
        }

        else if (collision.tag == "poop")
        {
            if (selfTalk.firstTimePoop)
            {
                space.GetComponentInChildren<Animator>().SetBool("close", true);
                space.GetComponentInChildren<Animator>().SetBool("again", false);
                enterSpace.Stop();
                exitSpace.Play();
                selfTalk.startPoopDialog = false;
            }
            else //
            {
                catStatus.toiletUsed = true;
                for (int i = 0; i < selfTalk.dialogues.Length; i++)
                {
                    Destroy(selfTalk.dialogues[i]);
                }
            }
        }

        else if(collision.tag == "bed")
        {
            space.GetComponentInChildren<Animator>().SetBool("close", true);
            space.GetComponentInChildren<Animator>().SetBool("again", false);
            hungryCase.GetComponentInChildren<Animator>().SetBool("close", true);
            hungryCase.GetComponentInChildren<Animator>().SetBool("again", false);
            toiletCase.GetComponentInChildren<Animator>().SetBool("close", true);
            toiletCase.GetComponentInChildren<Animator>().SetBool("again", false);

            if(catStatus.isHungry || !catStatus.toiletUsed)
            {
                enterSpace.Stop();
                exitSpace.Play();
            }
            
            
        }

        else if(collision.tag == "rainTalk")
        {
            day3Trigger.inNearMen = false;
        }


    }
}
