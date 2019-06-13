using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailEffect : MonoBehaviour {

    public GameObject x;
    float TimeDela = 0.2f;


	void Update () {
        if(TimeDela >= 0)
        {
            TimeDela -= Time.deltaTime;
        }
        else
        {
            if(Input.anyKey)
            Instantiate(x, transform.position - new Vector3(0,0.3f,0), transform.rotation);
            TimeDela = 0.2f;
        }
	}
}
