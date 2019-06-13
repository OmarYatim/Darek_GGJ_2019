using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostBehaviourType01 : MonoBehaviour {

    public Vector2 pointA;
    public Vector2 pointB;
    public float Speed;
    
   

    void Update () {
        transform.position = Vector2.Lerp(pointA, pointB, Mathf.PingPong(Time.time * Speed,1f));
        
        
	}
}
