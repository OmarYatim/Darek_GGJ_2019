using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow : MonoBehaviour {

    public GameObject follow;

    public float minX, maxX, minY, maxY;


	void Update () {
        transform.position = Vector3.Lerp(transform.position,follow.transform.position + new Vector3(0,3,-10),10*Time.deltaTime);

         transform.position= new Vector3( Mathf.Clamp(transform.position.x, minX, maxX),Mathf.Clamp(transform.position.y, minY, maxY),transform.position.z);
        

    }
}
