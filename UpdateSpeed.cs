using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateSpeed : MonoBehaviour {

    public int speed;
    public GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        speed = (int)player.GetComponent<PlayerController>().damagePerSecond;
        transform.GetComponent<Text>().text = "SPEED " + speed;
    }
}
