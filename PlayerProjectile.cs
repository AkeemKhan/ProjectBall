using UnityEngine;
using System.Collections;

public class PlayerProjectile : MonoBehaviour
{

    public float damage;
    public float blastRadius;
    public float blastForce;
    public float force;
    public GameObject shockwave;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Launch()
    {
        transform.GetComponent<Rigidbody>().AddForce(transform.forward * force);
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
                if (item.tag == "Enemy")
                {
                    Debug.Log("HIT");
                    item.GetComponent<EnemyController>().DamageHealth(damage);
                }
            }
        }
        Destroy(gameObject);
    }
}