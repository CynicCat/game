using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Color color=new Color(191/255,36/255,0);
    [SerializeField] private float colorIntensity = 4.3f;//HDR Color
    private float beamColorEnhance = 1;

    [SerializeField] private float maxLength = 100;//³¤
    [SerializeField] private float thickness = 9;//¿í
    [SerializeField] private float noiseScale = 3.14f;
    [SerializeField] private GameObject startVFX;
    [SerializeField] private GameObject endVFX;

    private LineRenderer lineRenderer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.material.color = color * colorIntensity;
        lineRenderer.material.SetFloat("_LaserThickness", thickness);
        lineRenderer.material.SetFloat("_LaserScale", noiseScale);

        ParticleSystem[] particles = transform.GetComponentsInChildren<ParticleSystem>();
        foreach(ParticleSystem p in particles)
        {
            Renderer r = p.GetComponent<Renderer>();
            r.material.SetColor("_EmissionColor", color * (colorIntensity + beamColorEnhance));
        }

    }

    private void UpdatePosition(Vector2 startPosition,Vector2 direction)
    {
        direction = direction.normalized;
        transform.position = startPosition;
        float rotationZ = Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.Euler(0, 0, rotationZ * Mathf.Rad2Deg);
    }

    private void UpdateEndPosition()
    {
        Vector2 startPositon = transform.position;
        float rotationZ = transform.rotation.eulerAngles.z;
        rotationZ *= Mathf.Deg2Rad;

        Vector2 direction = new Vector2(Mathf.Cos(rotationZ), Mathf.Sin(rotationZ));
    }
}
