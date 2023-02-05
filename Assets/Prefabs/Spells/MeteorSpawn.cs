using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
    public GameObject vfx;
    public Transform startPoint;
    public Transform endPoint;

    void Start()
    {


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                var startPos = startPoint.position;
                GameObject obj = Instantiate(vfx, startPos, Quaternion.identity);
                var endPos = endPoint.position;
                RotateTo(obj, endPos);
            }
        }



    }

    void RotateTo(GameObject obj, Vector3 destination)
    {
        var dir = destination - obj.transform.position;
        var rotation = Quaternion.LookRotation(dir);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1f);
    }
}
