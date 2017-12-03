using UnityEngine;
using System.Collections;

public class Trail : MonoBehaviour {

    public GameObject trailLight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Instantiate(trailLight, transform.position, transform.rotation);
	}
}
