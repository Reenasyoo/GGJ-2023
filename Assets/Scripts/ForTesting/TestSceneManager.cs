using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceneManager : MonoBehaviour
{
    public GameObject PrefabToSpawn;
    public Transform PositonToSpawnObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newObject = Instantiate(PrefabToSpawn);
            newObject.transform.position = PositonToSpawnObject.position;
        }
    }
}