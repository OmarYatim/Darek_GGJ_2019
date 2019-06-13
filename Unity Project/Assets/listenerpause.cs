using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class listenerpause : MonoBehaviour {
    public bool listen;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(listen)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
	}
}
