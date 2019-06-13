using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreAndHealth : MonoBehaviour {

    public Slider sld;
    public Text teddyBear;
    int teddyN;
    [SerializeField]
    GameObject Dead,UI;
    public GameObject x;
    public AudioSource xxx;
    
    void Start () {
		
	}
	
	void Update () {
        sld.value += Time.deltaTime;
        if(sld.value >= 100 )
        {
            GetComponent<Animator>().SetInteger("animation",4);
            StartCoroutine( death());
            Dead.SetActive(true);
            
            
        }
        teddyBear.text = teddyN.ToString();
    }

    IEnumerator death()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            sld.value += 25;
        }else if(collision.CompareTag("Teddy"))
        {
            Destroy(collision.gameObject);
            teddyN = PlayerPrefs.GetInt("teddyN", 0);
            teddyN++;
            PlayerPrefs.SetInt("teddyN", teddyN);
           
        }else if(collision.CompareTag("Finish"))
        {
            Time.timeScale = 0;
            UI.SetActive(true);
            xxx.Play();
        }else if(collision.CompareTag("Respawn"))
        {
           // GameObject x = collision.gameObject;
            Instantiate(x,transform.position + Vector3.up*3,transform.rotation,transform);
            Destroy(collision.gameObject);

        }
    }
}
