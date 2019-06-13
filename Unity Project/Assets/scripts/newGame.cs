using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newGame : MonoBehaviour {

    public AudioSource aS;
    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            aS.Play();
            StartCoroutine(loadSceneNew());
        }
    }

    IEnumerator loadSceneNew()
    {
        PlayerPrefs.SetInt("teddyN", 0);
        SceneManager.LoadSceneAsync(1);
        yield return null;
    }

}
