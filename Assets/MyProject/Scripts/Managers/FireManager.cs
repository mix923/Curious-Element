using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : Singleton<FireManager>
{
    [SerializeField]
    private List<Fire> firePoints;


    public void Start()
    {
        RandomFire();
    }

    public void RandomFire()
    {
        int x = Random.Range(0, firePoints.Count - 1);
        firePoints[x].gameObject.SetActive(true);
    }
}
