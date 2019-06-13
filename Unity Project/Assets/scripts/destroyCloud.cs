using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyCloud : MonoBehaviour {
    
	void Start () {
        Destroy(gameObject, 0.6f);
	}

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime);
    }


}
