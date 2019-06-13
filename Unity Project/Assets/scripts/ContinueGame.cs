using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueGame : MonoBehaviour {

    private void Start()
    {
        

        if (PlayerPrefs.GetInt("SceneLoad",1) == 1)
            GetComponent<SpriteRenderer>().color = Color.red ;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && PlayerPrefs.GetInt("SceneLoad",1) != 1)
        {
            StartCoroutine(loadSceneCont());
        }
    }

    IEnumerator loadSceneCont()
    {
        SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("SceneLoad",1));
        yield return null;
    }
}
