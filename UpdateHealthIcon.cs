using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateHealthIcon : MonoBehaviour {

    // Use this for initialization
    public int currentHealth;
    public int maxHealth;
    public GameObject healthBar;

	void Start () {
        healthBar = GameObject.Find("HealthBar");
	}
	
	// Update is called once per frame
	void Update () {
        currentHealth = (int)healthBar.GetComponent<Slider>().value;
        maxHealth = (int)healthBar.GetComponent<Slider>().maxValue;
        transform.GetComponent<Text>().text = currentHealth + " / " + maxHealth;
	}
}
