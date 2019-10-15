﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    private GameManager _manager;
    public GameObject _left;
    public GameObject _right;
    public GameObject _top;
    public GameObject _bottom;
    public Camera _camera;
    public GameObject _gun;


    void Start()
    {
        _manager = FindObjectOfType<GameManager>();

        float aspect_ratio = Screen.width / Screen.height;
        //here we colocate the different limits in the correct place
        {
            Vector2 position = new Vector2(0, 0);
            position.x = _camera.orthographicSize * aspect_ratio + 1;// +1 is a extra margin
            _right.transform.position = position;
        }

        {
            Vector2 position = new Vector2(0, 0);
            position.x = -(_camera.orthographicSize * aspect_ratio) - 1;// -1 is a extra margin
            _left.transform.position = position;
        }

        {
            Vector2 position = new Vector2(0, 0);
            position.y = _camera.orthographicSize + 1;//+1 is a extra margin;
            _top.transform.position = position;
        }

        {
            Vector2 position = new Vector2(0, 0);
            position.y = -_camera.orthographicSize - 1;//-1 is a extra margin
            _bottom.transform.position = position;
        }

        //we also colocate the torret in the correct position
        //it must be colocate at 1/4 left,
        {
            Vector2 position = new Vector2(0, 0);
            position.x = -_camera.orthographicSize * aspect_ratio *  3 / 4;
            position.y = -_camera.orthographicSize * 3 / 4;
            _gun.transform.position = position;
        }

        _manager.StartGame();
    }
}
