using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teletransport : MonoBehaviour
{
    public GameObject _destinationPoint;
    void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 _new_Position = other.gameObject.transform.position;
        _new_Position.x = _destinationPoint.transform.position.x;
        other.gameObject.transform.position = _new_Position;
    }
}
