using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alwaysLerp : MonoBehaviour {

    public float Pos;
    public float Origin = -2.54f;

    private void Start()
    {
        Origin = transform.position.x;
    }

    void Update () {
        transform.position = new Vector2(Mathf.Lerp(transform.position.x, Pos, 5 * Time.deltaTime),transform.position.y);
        
	}
}
