using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public float range = 6f;
    private GameObject player;
    private GameObject holo;
    private GameObject building;
    public GameObject baseCircle;
    public bool built;

    public GameObject tower, towerHolo, wall, wallHolo;

    public enum Type
    {
        Tower,
        Wall
    }

    public Type curType;

    private void Update()
    {
        if (!built)
        {
            Show();
        }
    }

    void Start()
    {
        if (curType == Type.Tower)
        {
            holo = towerHolo;
            building = tower;
        }
        else if (curType == Type.Wall)
        {
            holo = wallHolo;
            building = wall;
        }


        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Show()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer < range)
        {
            holo.SetActive(true);
        }
        else
        {
            holo.SetActive(false);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void SetBuilding()
    {
        building.SetActive(true);
        holo.SetActive(false);
    }
}
