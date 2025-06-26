using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private ParticleSystem system;
    
    void Start()
    {
        system = GetComponent<ParticleSystem>();
    }
    
    void Update()
    {
        if (system != null && !system.IsAlive(true))
        {
            Destroy(system.gameObject);
        }
    }
}
