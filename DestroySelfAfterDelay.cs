using UnityEngine;
using System.Collections;

public class DestroySelfAfterDelay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Destroy", 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
