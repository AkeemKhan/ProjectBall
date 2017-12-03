using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public GameObject shockwave;
    public float currentHealth;
    public float maxHealth;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        SyncHealth();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.transform.name == "Player")
        {
            currentHealth -= 0;
        }
    }

    public void SyncHealth()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            GameObject.Find("Player").GetComponent<PlayerController>().MinorBuff();
            Instantiate(shockwave, transform.position, transform.rotation);
        }
    }

    public void DamageHealth(float damage)
    {
        currentHealth = currentHealth - damage;
    }
}
