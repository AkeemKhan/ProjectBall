using UnityEngine;
using System.Collections;

public class FireDamage : MonoBehaviour {

    // Use this for initialization
    public float damage = 10;
    public float radius;

	void Start () {
        radius = (transform.localScale.x)/2;
	}
	
	// Update is called once per frame
	void Update () {
        FireDamageOverTime(transform.position, radius);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Player")
        {
            GameObject.Find("Player").GetComponent<PlayerController>().DamagePlayer(damage);
            Debug.Log(GameObject.Find("Player").GetComponent<PlayerController>().currentHealth);

            // counter = 0;
        }

    }

    public void FireDamageOverTime(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach(Collider item in hitColliders)
        {
            if(item.name == "Player")
            {
                GameObject.Find("Player").GetComponent<PlayerController>().DamagePlayer(damage*Time.deltaTime);
                Debug.Log("Damage taken " + damage);
            }

        }
    }



}
