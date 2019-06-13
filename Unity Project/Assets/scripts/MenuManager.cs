using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    [SerializeField]
    GameObject UI;

    public AudioSource btn, Mbtn, ghost;

    private void Start()
    {
        Cursor.visible = true;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Time.timeScale = 0;
            UI.SetActive(true);
        }
    }
    public void Resume()
    {
        UI.SetActive(false);
        Time.timeScale = 1;
        btn.Play();
    }
    public void Replay()
    {
        //EditorSceneManager.LoadScene();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        btn.Play();
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        Time.timeScale = 1;
        btn.Play();

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        Mbtn.Play();
    }



}
