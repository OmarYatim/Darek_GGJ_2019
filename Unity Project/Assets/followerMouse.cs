using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followerMouse : MonoBehaviour {
    
	void Start () {
		
	}
    Vector2 dir;
    void Update () {
        dir = Input.mousePosition;
        
        dir = Camera.main.ScreenToWorldPoint(dir);

        // Debug.Log(dir);
        

        transform.LookAt(dir);
        transform.rotation = new Quaternion(transform.rotation.x,0,transform.rotation.z,1);
    }
}
