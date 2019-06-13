using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrail : MonoBehaviour {

    public GameObject mask;
    //GameObject x;
   // float waitTime = 0.05f;

    private void Start()
    {
        InvokeRepeating("trail", 0, 0.05f);
    }

    void trail()
    {
        Instantiate(mask, transform.position, transform.rotation);
    }


  /*  void Update () {
		if(waitTime >=0)
        {
            waitTime -= Time.deltaTime;
        }
        else
        {
            
            waitTime = 0.05f;
        }
	}*/
}
