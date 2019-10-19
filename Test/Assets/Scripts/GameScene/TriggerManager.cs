using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public GameObject _teleport_point = null;
    void OnTriggerEnter2D(Collider2D other)
    {
        //if the tag is a plane, we move the plane to the teleport point
        if (other.CompareTag("Plane"))
        {
            if (_teleport_point != null)
            {
                //if the collision is with a plane, we teleport to the destination point
                Vector2 _new_Position = other.gameObject.transform.position;
                _new_Position.x = _teleport_point.transform.position.x;//we only set the X coord, so the Y is the same
                other.gameObject.transform.position = _new_Position;
            }
        }
        else
        {   //if the objet that collides is a bullet, we return to the pool
            if (other.CompareTag("Bullet"))
            {
                other.GetComponentInParent<PoolManager>().ReturnItem(other.gameObject);
            }
        }
    }
}
