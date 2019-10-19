using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    public float _velocity = 2;

    void Update()
    {
        //we move the object allways to the right
        transform.position += _velocity * Time.deltaTime * transform.right;
    }
}
