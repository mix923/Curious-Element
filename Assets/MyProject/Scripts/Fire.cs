using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private float lifetime = 100f;
    [SerializeField]
    private Transform player;

    private void Update()
    {
        transform.GetChild(2).LookAt(player);
    }

    public void Extinguish(float damage)
    {
        lifetime -= damage;
        UIManager.Instance.SetProgressExtinguish(lifetime);
        if (lifetime <= 0)
        {
            GameEventManager.Instance.CompleteLevel();
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            GameEventManager.Instance.PlayerNearFire(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GameEventManager.Instance.PlayerExitFire();
        }
    }
}
