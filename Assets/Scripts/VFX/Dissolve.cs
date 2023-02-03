using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{


    public float radius = 5;
    public float intensity = 1;
    public float noiseStrength = 0;
    public float edgeSize = 1;
    public float smooth = 1;
    public float emissionStrength = 1;

    public bool drawInEditor = true;

    void Start()
    {

    }

    void Update()
    {
        UpdateShaderData();
        //radius += Time.deltaTime * 10f;
    }

    private void OnDrawGizmosSelected()
    {
        if (drawInEditor)
            Gizmos.DrawWireSphere(transform.position, radius);
    }

    void UpdateShaderData()
    {
        Shader.SetGlobalVector("_Position", transform.position);
        Shader.SetGlobalFloat("_Radius", radius);
        Shader.SetGlobalFloat("_Intensity", intensity);
        Shader.SetGlobalFloat("_NoiseStrength", noiseStrength);
        Shader.SetGlobalFloat("_EdgeSize", edgeSize);
        Shader.SetGlobalFloat("_Smooth", smooth);
        Shader.SetGlobalFloat("_EmissionStrength", emissionStrength);
    }

}
