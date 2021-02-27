using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class day2Enter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndPrint(2.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        this.gameObject.SetActive(false);
    }
}
