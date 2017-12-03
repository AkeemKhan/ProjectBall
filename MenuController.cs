using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

    // Use this for initialization

    
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Menu()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
    }

    public void LevelSelector()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);

    }

    public void HowToPlay()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
