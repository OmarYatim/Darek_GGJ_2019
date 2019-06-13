using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject SettingsMenu;
    public float posNew;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MainMenu.GetComponent<alwaysLerp>().Pos = posNew;
            SettingsMenu.GetComponent<alwaysLerp>().Pos = posNew+9;

        }
    }

   
}
