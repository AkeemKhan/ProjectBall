using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ArenaHealth : MonoBehaviour {

    public GameObject arenaEnemy;
    private EnemyController eController;
    
    // Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (arenaEnemy != null)
        {
            eController = arenaEnemy.GetComponent<EnemyController>();
            transform.GetComponent<Slider>().maxValue = eController.maxHealth;
            transform.GetComponent<Slider>().value = eController.currentHealth;
        }
        else
        {
            transform.GetComponent<Slider>().value = 0;
        }
        
    }
}
