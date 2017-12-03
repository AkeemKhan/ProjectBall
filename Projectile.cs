using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float damage;
    public float blastRadius;
    public float blastForce;
    public float force;
    public GameObject shockwave;

	// Use this for initialization
	void Start () {
        transform.GetComponent<Rigidbody>().AddForce(transform.forward * force);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter()
    {
        Instantiate(shockwave, transform.position, transform.rotation);
        

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, blastRadius);
        foreach (Collider item in hitColliders)
        {
            if (item.GetComponent<Rigidbody>() != null)
            {
                item.GetComponent<Rigidbody>().AddExplosionForce(blastForce, transform.position, blastRadius);
                if (item.name == "Player")
                {
                    item.GetComponent<PlayerController>().DamagePlayer(damage);
                }

            }
        }
        Destroy(gameObject);
    }
}
