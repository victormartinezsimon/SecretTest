using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public GameObject _teleport_point;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("plane"))
        {
            //if the collision is with a plane, we teleport to the destination point
            Vector2 _new_Position = other.gameObject.transform.position;
            _new_Position.x = _teleport_point.transform.position.x;//we only set the X coord
            other.gameObject.transform.position = _new_Position;
        }
        if(other.CompareTag("bullet"))
        {
            //if the collision is with a bullet, we return it to the pool
            other.GetComponentInParent<PoolManager>().returnItem(other.gameObject);
        }
    }
}
