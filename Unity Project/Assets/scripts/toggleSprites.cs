using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleSprites : MonoBehaviour {


    public Sprite offF;
    public Sprite offE;
    Sprite onE;
    Sprite onF;
    public bool State = true;

	void Start () {
        onE = transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
        onF = GetComponent<SpriteRenderer>().sprite;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(State)
            {
                GetComponent<SpriteRenderer>().sprite = offF;
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = offE;
                Camera.main.GetComponent<listenerpause>().listen = false;
                State = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = onF;
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = onE;
                Camera.main.GetComponent<listenerpause>().listen = false;
                State = true;
            }
        }
    }
}
