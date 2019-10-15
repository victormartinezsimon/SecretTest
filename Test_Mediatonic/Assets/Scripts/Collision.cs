using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        //there is a new collision, we must notify the gameManager
        GameManager._instance.PlaneHit();
        col.transform.parent.GetComponent<PoolManager>().returnItem(col.transform.gameObject);
        this.transform.parent.GetComponent<PoolManager>().returnItem(this.transform.gameObject);
    }
}
