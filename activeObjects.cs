using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeObjects : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] toActivate;
    public GameObject[] toDisactivate;
    void Start()
    {
        for (int i = 0; i < toDisactivate.Length; i++)
        {
            Debug.Log("LOLO");
            toDisactivate[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.active)
        {
            for(int i = 0; i < toActivate.Length; i++)
            {
                toActivate[i].SetActive(true);
            }
        }

        else
        {
            for (int i = 0; i < toActivate.Length; i++)
            {
                toActivate[i].SetActive(false);
            }
        }
    }
}
