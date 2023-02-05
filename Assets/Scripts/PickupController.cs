using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runtime.Actor.InteractActions;

public class PickupController : MonoBehaviour
{
    public int maxPickups = 3;
    public GameObject[] pickups;
    public List<Transform> spawnLocations = new List<Transform>();
    public int pickupsActive = 0;

    public List<GameObject> spawnedPickups = new List<GameObject>();

    private void Update()
    {
        if (pickupsActive < maxPickups)
        {
            int index = Random.Range(0, spawnLocations.Count);
            if (spawnLocations[index].GetComponent<CheckSpawnLocation>().isTaken)
            {
                return;
            }
            GameObject spawnedPickup = Instantiate(pickups[Random.Range(0, 2)], spawnLocations[index].position, transform.rotation);
            spawnLocations[index].GetComponent<CheckSpawnLocation>().isTaken = true;
            spawnedPickup.GetComponent<PickupAction>().pickupController = this;
            spawnedPickups.Add(spawnedPickup);
            pickupsActive++;
            print("a");
        }
    }
}
