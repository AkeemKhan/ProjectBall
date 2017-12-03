using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateDMGAndRange : MonoBehaviour {

    public int damage;
    public int range;
    public GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        damage = (int)player.GetComponent<PlayerController>().damagePerSecond;
        range = (int)player.GetComponent<PlayerController>().damageRadius;
        transform.GetComponent<Text>().text = "DMG "+ damage + " / " + " RANGE " + range;
    }
}
