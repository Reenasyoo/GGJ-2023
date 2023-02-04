using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRipples : MonoBehaviour
{
    public GameObject ripplesVFX;
    public GameObject hitVFX;
    private Material mat;
    //List<ContactPoint> contactPointList = new List<ContactPoint>();


    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        RaycastHit hit;
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        if (Physics.Raycast(ray, out hit, 100.0f))
    //        {
    //            ActivateVFX(hit.point);
    //        }
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        ActivateVFX(collision.GetContact(0).point);
    }
    

    public void ActivateVFX(Vector3 point)
    {
        var ripples = Instantiate(ripplesVFX, transform) as GameObject;

        if (hitVFX != null)
        {
            var hit = Instantiate(hitVFX, transform) as GameObject;
            hit.transform.position = point;
        }

        var psr = ripples.transform.GetChild(0).GetComponent<ParticleSystemRenderer>();

        mat = psr.material;
        mat.SetVector("_SphereCenter", point);
    }
}