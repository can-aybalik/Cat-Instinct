using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject cat;
    public Vector3 newPos;
    // Start is called before the first frame update
    void Start()
    {
        newPos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        newPos.x = cat.transform.position.x;
        newPos.y = cat.transform.position.y;
        this.gameObject.transform.position = newPos;
    }
}
