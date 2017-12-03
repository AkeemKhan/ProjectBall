using UnityEngine;
using System.Collections;

public class BuffPickup : MonoBehaviour {

    // Use this for initialization
    public float healValue = 10;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Player")
        {
            GameObject.Find("Player").GetComponent<PlayerController>().MajorBuff();
            GameObject.Find("Player").GetComponent<PlayerController>().InstantHeal(healValue);
            Debug.Log(GameObject.Find("Player").GetComponent<PlayerController>().currentHealth);
            Destroy(gameObject);
        }
    }
}
