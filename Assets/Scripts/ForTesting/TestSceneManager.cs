using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceneManager : MonoBehaviour
{
    public GameObject MeteorToSpawn;
    //public Transform PositonToSpawnObject;

    public Transform MeteorTarget;
    public float MeteorInterval;
    public float MeteorSpawnHigh = 5f;

    bool MeteoritShover = false;
    float x;
    float z;

    //private void Start()
    //{

    //}

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    //GameObject newObject = Instantiate(PrefabToSpawn);
        //    //newObject.transform.position = PositonToSpawnObject.position;
        //    if (!MeteoritShover)
        //    {
        //        MeteoritShover = true;
        //        StartCoroutine(LaunchMeteor());
        //    }
        //    else
        //    {
        //        MeteoritShover = false;
        //    }
        //}

        if (!MeteoritShover)
        {
            MeteoritShover = true;
            StartCoroutine(LaunchMeteor());
        }
        else
        {

        }
    }

    IEnumerator LaunchMeteor()
    {
        while (MeteoritShover)
        {
            x = Random.Range(-5f, 5f);
            z = Random.Range(-5f, 5f);

            Vector3 spawnPosition = new Vector3(x, MeteorSpawnHigh, z);
            GameObject spawnedObject = Instantiate(MeteorToSpawn, spawnPosition, Quaternion.identity);

            Vector3 direction = (MeteorTarget.position - spawnPosition).normalized;
            Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
            rb.AddForce(direction * 10, ForceMode.Impulse);


            //GameObject meteor = Instantiate(MeteorToSpawn);
            //meteor.transform.position = PositonToSpawnObject.position;

            yield return new WaitForSeconds(MeteorInterval);
        }

        MeteoritShover = false;
    }
}