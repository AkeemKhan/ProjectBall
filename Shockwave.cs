using UnityEngine;
using System.Collections;

public class Shockwave : MonoBehaviour {

    // Use this for initialization

    public float intensityDec;
    public float durationCounter;
    public float rangeInc;
    private Light light;
	void Start () {
        light = transform.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        durationCounter -= Time.deltaTime;
        light.intensity -= intensityDec * Time.deltaTime;
        light.range += rangeInc * Time.deltaTime;
        if (durationCounter < 0)
            Destroy(gameObject);
	}
}
