using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostBehaviourType03 : MonoBehaviour {

    // When the boy enters the big circle collider this will become true
    // And the ghost will start shooting 
    private bool boyInZone;

    // the thing the ghost will shoot on the boy
    public GameObject projectile;

    public float projectileForce;

    // Shooting Direction 
    private Vector2 Dir;

    //target
    public GameObject target;

    //delay between two projectiles
    public float waitTime;

	void Start () {
        boyInZone = false;
	}
	
	
	void Update () {
        if (boyInZone)
        {
            this.Dir = (this.target.transform.position - this.transform.position).normalized;
            StartCoroutine(shootingWithDelay());
        }
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        target = col.gameObject;
        this.boyInZone = true;
        
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        target = null;
        this.boyInZone = false;
        this.Dir = Vector2.zero;
    }

    void shoot()
    {
        GameObject GO = Instantiate(projectile, transform.position, transform.rotation);
        GO.AddComponent(typeof(Rigidbody2D));
        GO.GetComponent<Rigidbody2D>().gravityScale = 0f;
        GO.GetComponent<Rigidbody2D>().velocity = Dir.normalized * projectileForce;
    }

    IEnumerator shootingWithDelay()
    {
        while (true)
        {
            shoot();
            yield return new WaitForSeconds(waitTime);
        }
    }

}
