using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private PoolManager _pool;
    private PlaneGenerator _generator;
    void Start()
    {
        _pool = GetComponentInParent<PoolManager> ();
        _generator = GetComponentInParent<PlaneGenerator>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //there is a new collision, we must notify the gameManager
        _pool.ReturnItem(this.gameObject);//we return the plane to the pool
        col.transform.GetComponentInParent<PoolManager>().ReturnItem(col.gameObject);//we return the bullet to the pool
        _generator.PlaneDestroyed();//we notify the generator that the plane is destroyed
    }
}
