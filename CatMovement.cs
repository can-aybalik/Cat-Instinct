using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{

    private IEnumerator coroutine;
    // Start is called before the first frame update
    public float MovementSpeed = 1f;
    public Animator anim;
    public Rigidbody2D catRb;
    public bool canMove = true;

    public AudioSource catWalking;

    public GameObject fadeBeginning;
    void Start()
    {
        //fadeBeginning.SetActive(true);
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (canMove)
        {
            var movement = Input.GetAxis("Horizontal");
            var upDown = Input.GetAxis("Vertical");
            catRb.transform.position += new Vector3(movement, upDown) * Time.deltaTime * MovementSpeed;

            if (movement != 0 || upDown != 0)
            {
                anim.SetBool("move", true);
            }
            else
            {
                anim.SetBool("move", false);
                catRb.velocity = Vector3.zero;
            }

            if (movement > 0)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }

            if (movement < 0)
            {
                transform.rotation = new Quaternion(0, -180, 0, 0);
            }

            if(movement != 0 || upDown != 0)
            {
                if(!catWalking.isPlaying)
                    catWalking.Play();
            }
            else
            {
                catWalking.Stop();
                anim.SetBool("move", false);
                catRb.velocity = Vector3.zero;
            }
        }

    }

    

    
}
