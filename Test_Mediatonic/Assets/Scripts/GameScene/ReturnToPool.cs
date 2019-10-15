using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPool : MonoBehaviour
{
    public PoolManager _pool;

    void OnTriggerEnter2D(Collider2D other)
    {
        _pool.returnItem(other.transform.gameObject);
    } 
}
