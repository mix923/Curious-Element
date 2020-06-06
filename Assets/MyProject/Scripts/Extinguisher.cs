using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    public bool IsActive { get; set; }

    private ParticleSystem particleSystem;

    private void Start()
    {
        particleSystem = transform.GetChild(0).transform.GetComponent<ParticleSystem>();
        particleSystem.enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsActive)
        {
            if (Input.GetMouseButtonDown(1)) particleSystem.enableEmission = true;
            if (Input.GetMouseButtonUp(1)) particleSystem.enableEmission = false;
        }
    }
}
