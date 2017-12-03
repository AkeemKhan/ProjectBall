using UnityEngine;
using System.Collections;

public class DamageOverTime : MonoBehaviour {

    // Use this for initialization

    public GameObject player;

	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        DetectAndDamageEnemies();
    }

    public void DetectAndDamageEnemies()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, player.GetComponent<PlayerController>().damageRadius);
        foreach (Collider item in hitColliders)
        {
            //If Detected
            if (item.tag == "Enemy")
            {
                GameObject.Find("EnemyHealth").GetComponent<ArenaHealth>().arenaEnemy = item.gameObject;
                item.GetComponent<EnemyController>().DamageHealth((player.GetComponent<PlayerController>().damagePerSecond*Time.deltaTime)*0);
            }

        }
    }
}
