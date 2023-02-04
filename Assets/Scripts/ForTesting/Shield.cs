using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public string parameterName;
    Material material;

    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        material.SetFloat(parameterName, 1);
    }

    private void OnCollisionExit(Collision collision)
    {
        material.SetFloat(parameterName, 0);
    }
}