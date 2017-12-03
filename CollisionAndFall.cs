using UnityEngine;
using System.Collections;

public class CollisionAndFall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Player")
        {
            collider.transform.GetComponent<PlayerController>().DamagePlayer(1000);
        }
        if (collider.tag == "Enemy")
        {
            Destroy(collider);
        }


    }


}
