using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitApp : MonoBehaviour {

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Application.Quit(); //todo more
        }
    }

   
}
