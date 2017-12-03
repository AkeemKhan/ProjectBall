using UnityEngine;
using System.Collections;

public class AIEnemyLight : MonoBehaviour {

    public bool playerDetected = false;
    public bool engagePlayer = false;
    public float detectRange;
    public float enageRange;
    public float engageCooldown;
    public float engageRequirement;
    public float force;
    public float blastRange;
    public float blastCounter;
    public float blastCooldown;
    public float blastDamage;
    public float collisionDamage;

    private float persueRange = 1000;

    public GameObject shockwave;
    private Vector3 playerPosition;
    private Vector3 launchPosition;

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        engageCooldown += Time.deltaTime;
        blastCounter += Time.deltaTime;
        //Detect player position constantly

        if (engageCooldown > engageRequirement)
            DetectAndEngagePlayerPosition();
        if (blastCounter > blastCooldown)
            Blast();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.transform.name == "Player")
        {
            col.transform.GetComponent<PlayerController>().DamagePlayer(collisionDamage);
        }
    }

    public void DetectAndEngagePlayerPosition()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectRange);
        foreach (Collider item in hitColliders)
        {
            //If Detected
            if (item.name == "Player")
            {
                detectRange = persueRange;
                //Get Random position around player
                playerPosition = item.transform.position;
                launchPosition = new Vector3(Random.Range(playerPosition.x - enageRange, playerPosition.x + enageRange), playerPosition.y, Random.Range(playerPosition.z - enageRange, playerPosition.z + enageRange));

                //Face player
                transform.rotation = Quaternion.LookRotation(playerPosition - transform.position);

                //Engage attack
                transform.GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Force);
                engagePlayer = true;
                engageCooldown = 0;

            }

        }
    }

    public void Blast()
    {

        Debug.Log("BLAST!");
        bool blast = false;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, blastRange);
        foreach (Collider item in hitColliders)
        {
            if (item.name == "Player")
            {
                blast = true;
            }
        }

        if (blast && blastCounter > blastCooldown)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            foreach (Collider item in hitColliders)
            {
                if(item.GetComponent<Rigidbody>()!=null)
                {
                    item.GetComponent<Rigidbody>().AddExplosionForce(force*3, transform.position, blastRange);
                    if (item.name == "Player")
                    {
                        item.GetComponent<PlayerController>().DamagePlayer(blastDamage);
                    }
                        
                }
                    
            }
            Instantiate(shockwave,transform.position,transform.rotation);
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
        blastCounter = 0;
    }



}
