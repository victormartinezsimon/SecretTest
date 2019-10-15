using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject _gun_60;
    public GameObject _gun_90;
    public GameObject _gun_30;

    public PoolManager _bullet_pool;
    
    void Update()
    {
        float currentDegrees = 60;
        if(Input.GetKey(KeyCode.UpArrow))
        {
            currentDegrees = 90;
            _gun_90.SetActive(true);
            _gun_30.SetActive(false);
            _gun_60.SetActive(false);
        }
        else
        {
            if(Input.GetKey(KeyCode.DownArrow))
            {
                currentDegrees = 30;
                _gun_30.SetActive(true);
                _gun_60.SetActive(false);
                _gun_90.SetActive(false);
            }
            else
            {
                currentDegrees = 60;
                _gun_60.SetActive(true);
                _gun_30.SetActive(false);
                _gun_90.SetActive(false);
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shot(currentDegrees);
        }
    }

    private void Shot(float currentDegrees)
    {
        GameObject bullet;
        if(_bullet_pool.getItem(out bullet))
        {
            //we move to the location of _gun_XX
            //I will use gun_60 because all of them have the same transform
            Vector2 position = _gun_60.transform.position;
            bullet.transform.position = position;

            bullet.SetActive(true);

            //we rotate to the correct direction
            bullet.transform.rotation = Quaternion.Euler(0, 0, currentDegrees); 
        }
    }
}
