using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerCannon : MonoBehaviour
{

    public Vector3 enemyPosition;
    public Vector3 launchPosition;
    public float offset;
    public GameObject projectile;
    public int instantiationRange;
    public float detectRange;


    //STats
    public float projectileSpeed;
    public float projectileDamage;
    public float projectileRange;


    // Use this for initialization

    public void DetectAndFire()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, projectileRange);
        List<Collider> enemyColliders = new List<Collider>();

        foreach (Collider item in hitColliders)
        {
            if (item.tag == "Enemy")
                enemyColliders.Add(item);
        }
        Debug.Log("NO. "+enemyColliders.Count);
        if (enemyColliders.Count > 0)
        {

            System.Random rn = new System.Random();
            int index = rn.Next(0, enemyColliders.Count);
            Collider randomEnemy = enemyColliders[index];

            enemyPosition = randomEnemy.transform.position;
            transform.rotation = Quaternion.LookRotation(enemyPosition - transform.position);

            //Get position of player
            launchPosition = new Vector3(Random.Range(enemyPosition.x - offset, enemyPosition.x + offset), enemyPosition.y,
            Random.Range(enemyPosition.z - offset, enemyPosition.z + offset));
            
            //Face Enemy
            transform.rotation = Quaternion.LookRotation(enemyPosition - transform.position);

            //Engage attack
            GameObject theProj = Instantiate(projectile, transform.position + (transform.forward * instantiationRange), transform.rotation) as GameObject;
            theProj.GetComponent<PlayerProjectile>().damage = projectileDamage;
            theProj.GetComponent<PlayerProjectile>().blastForce = 10;
            theProj.GetComponent<PlayerProjectile>().force = projectileSpeed;
            theProj.GetComponent<PlayerProjectile>().blastRadius = 10;
            theProj.GetComponent<PlayerProjectile>().Launch();
        }

     }
 }


