using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnSystem : MonoBehaviour {

    public int maxHealthPickups = 5;
    public int maxFire = 10;
    public int maxLightEnemies = 10;
    public int maxStrongEnemies = 3;

    public GameObject healthPickup;
    public GameObject buffPickup;
    public GameObject fire;
    public GameObject player;
    public GameObject enemyLight;
    public GameObject enemyStrong;
    public GameObject enemyBoss;
    public GameObject watchTowerLight;
    public GameObject watchTowerStrong;

    // Use this for initialization
    void Start () {
        SpawnItems();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SpawnItems()
    {
        //Health
        GameObject[] items = GameObject.FindGameObjectsWithTag("ObjectSpawn");
        List<GameObject> listOfSpawns = new List<GameObject>(items);

        SpawnSetOfObjects(healthPickup, maxHealthPickups, listOfSpawns);
        SpawnSetOfObjects(fire, maxFire, listOfSpawns);
        SpawnSetOfObjects(enemyLight, maxLightEnemies, listOfSpawns);
        SpawnSetOfObjects(enemyStrong, maxStrongEnemies, listOfSpawns);
        SpawnSetOfObjects(enemyBoss, 1, listOfSpawns);
        SpawnSetOfObjects(watchTowerLight, 4, listOfSpawns);
        SpawnSetOfObjects(watchTowerStrong, 1, listOfSpawns);

        //for(int i = 0; i < maxHealthPickups; i++)
        //{
        //    System.Random rnd = new System.Random();
        //    int randomNumber = rnd.Next(0, listOfSpawns.Count);
        //    Vector3 position = listOfSpawns[randomNumber].transform.position;
        //    listOfSpawns.RemoveAt(randomNumber);
        //    Instantiate(healthPickup, position, new Quaternion()); 
        //    Debug.Log("Spawn at: " + position);
        //}

        ////Fire
        //for (int i = 0; i < maxFire; i++)
        //{
        //    System.Random rnd = new System.Random();
        //    int randomNumber = rnd.Next(0, listOfSpawns.Count);
        //    Vector3 position = listOfSpawns[randomNumber].transform.position;
        //    listOfSpawns.RemoveAt(randomNumber);
        //    Instantiate(fire, position, new Quaternion());
        //    Debug.Log("Spawn at: " + position);
        //}

        ////Light Enemies
        //for (int i = 0; i < maxLightEnemies; i++)
        //{
        //    System.Random rnd = new System.Random();
        //    int randomNumber = rnd.Next(0, listOfSpawns.Count);
        //    Vector3 position = listOfSpawns[randomNumber].transform.position;
        //    listOfSpawns.RemoveAt(randomNumber);
        //    Instantiate(enemyLight, position, new Quaternion());
        //    Debug.Log("Spawn at: " + position);
        //}

        ////Strong Enemies
        //for (int i = 0; i < maxStrongEnemies; i++)
        //{
        //    System.Random rnd = new System.Random();
        //    int randomNumber = rnd.Next(0, listOfSpawns.Count);
        //    Vector3 position = listOfSpawns[randomNumber].transform.position;
        //    listOfSpawns.RemoveAt(randomNumber);
        //    Instantiate(enemyStrong, position, new Quaternion());
        //    Debug.Log("Spawn at: " + position);
        //}

        ////Boss
        //for (int i = 0; i < 1; i++)
        //{
        //    System.Random rnd = new System.Random();
        //    int randomNumber = rnd.Next(0, listOfSpawns.Count);
        //    Vector3 position = listOfSpawns[randomNumber].transform.position;
        //    listOfSpawns.RemoveAt(randomNumber);
        //    Instantiate(enemyBoss, position, new Quaternion());
        //    Debug.Log("Spawn at: " + position);
        //}

        ////Buffs
        //for (int i = 0; i < maxHealthPickups; i++)
        //{
        //    System.Random rnd = new System.Random();
        //    int randomNumber = rnd.Next(0, listOfSpawns.Count);
        //    Vector3 position = listOfSpawns[randomNumber].transform.position;
        //    listOfSpawns.RemoveAt(randomNumber);
        //    Instantiate(buffPickup, position, new Quaternion());
        //    Debug.Log("Spawn at: " + position);
        //}

        ////WT Light
        //for (int i = 0; i < 2; i++)
        //{
        //    System.Random rnd = new System.Random();
        //    int randomNumber = rnd.Next(0, listOfSpawns.Count);
        //    Vector3 position = listOfSpawns[randomNumber].transform.position;
        //    listOfSpawns.RemoveAt(randomNumber);
        //    Instantiate(watchTowerLight, position, new Quaternion());
        //    Debug.Log("Spawn at: " + position);
        //}

        ////WT Strong
        //for (int i = 0; i < 1; i++)
        //{
        //    System.Random rnd = new System.Random();
        //    int randomNumber = rnd.Next(0, listOfSpawns.Count);
        //    Vector3 position = listOfSpawns[randomNumber].transform.position;
        //    listOfSpawns.RemoveAt(randomNumber);

        //    Debug.Log("Spawn at: " + position);
        //}


    }

    public void SpawnSetOfObjects(GameObject obj, int count, List<GameObject> listOfSpawns)
    {
        System.Random rnd = new System.Random();
        for (int i = 0; i < count; i++)
        {
            int randomNumber = rnd.Next(0, listOfSpawns.Count);
            Vector3 referencePosition = listOfSpawns[randomNumber].transform.position;
            SpawnObject(obj, referencePosition);
            listOfSpawns.RemoveAt(randomNumber);
        }
    }

    public void SpawnObject(GameObject obj, Vector3 referencePosition)
    {
        RaycastHit rc;
        if (Physics.Raycast(referencePosition, Vector3.down, out rc))
        {
            Vector3 targetLocation = rc.point;
            targetLocation += new Vector3(0, 1, 0);
            Instantiate(obj, targetLocation, new Quaternion());
        }
    }

}
