using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followMouse : MonoBehaviour {

    Vector2 mousePos;

	void Start () {
        Cursor.visible = false;
	}
	
	void Update () {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = mousePos;
	}
}
