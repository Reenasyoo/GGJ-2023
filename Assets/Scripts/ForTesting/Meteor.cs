using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}