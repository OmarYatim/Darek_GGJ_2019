using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thunderS : MonoBehaviour {

    public GameObject mask;
    public AudioSource aS;

	void Start () {
        InvokeRepeating("clap",2f,5.5f);
	}
	
	void clap()
    {
        StartCoroutine(clapCo());
    }

    IEnumerator clapCo()
    {
        aS.Play();
        mask.transform.localScale *= 3 ;
        yield return new WaitForSeconds(0.4f);
        mask.transform.localScale *= 0.33333f;
        yield return new WaitForSeconds(0.3f);
        mask.transform.localScale *= 3;
        yield return new WaitForSeconds(0.3f);
        mask.transform.localScale *= 0.33333f;
    }

}
