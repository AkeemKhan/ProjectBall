using UnityEngine;
using System.Collections;

public class MiniShockwave : MonoBehaviour {
    
    // Use this for initialization
    public float intensity;
    public float durationCounter;
    public float range;
    private Light light;
    void Start()
    {
        light = transform.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        durationCounter -= Time.deltaTime;
        light.intensity -= 7 * Time.deltaTime;
        light.range += 100 * Time.deltaTime;
        if (durationCounter < 0)
            Destroy(gameObject);
    }
}
