using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cancelSettingMenu : MonoBehaviour {
    public GameObject mainMenu;
    public GameObject Settings;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mainMenu.GetComponent<alwaysLerp>().Pos = mainMenu.GetComponent<alwaysLerp>().Origin;
            Settings.GetComponent<alwaysLerp>().Pos = Settings.GetComponent<alwaysLerp>().Origin;
        }
    }

}
