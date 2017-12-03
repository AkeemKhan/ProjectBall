using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{

    public int scene;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter()
    {
        LoadScene();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(scene);
    }

}
