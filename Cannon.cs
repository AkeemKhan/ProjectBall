using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {

    public float detectRange;
    public Vector3 playerPosition;
    public Vector3 launchPosition;
    public float offset;
    public GameObject projectile;
    public float launchCooldown;
    public float launchCounter;
    public int instantiationRange;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        launchCounter += Time.deltaTime;
        DetectAndFire();
    }

    public void DetectAndFire()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectRange);
        foreach (Collider item in hitColliders)
        {
            //If Detected
            if (item.name == "Player")
            {
                playerPosition = item.transform.position;
                transform.rotation = Quaternion.LookRotation(playerPosition - transform.position);
                detectRange = 1000;
                if (launchCounter > launchCooldown)
                {
                    //Get position of player
                    launchPosition = new Vector3(Random.Range(playerPosition.x - offset, playerPosition.x + offset), playerPosition.y, 
                    Random.Range(playerPosition.z - offset, playerPosition.z + offset));
                //Face player
                    transform.rotation = Quaternion.LookRotation(launchPosition - transform.position);

                //Engage attack
                    Instantiate(projectile, transform.position+(transform.forward*instantiationRange), transform.rotation);
                    launchCounter = 0;
                }     
            }

        }
    }

}
