﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}