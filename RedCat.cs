using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCat : MonoBehaviour
{
    public GameObject Cat;
    Vector3 catLocation;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        catLocation = Cat.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        catLocation = Cat.transform.position;
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, catLocation, speed * Time.deltaTime);
    }
}
