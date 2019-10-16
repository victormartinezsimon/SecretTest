using System.Collections;
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

    private Vector2 _topRight;
    private Vector2 _bottomLeft;

    public Vector2 TopRight
    {
        get { return _topRight; }
    }

    public Vector2 BottomLeft
    {
        get { return _bottomLeft;}
    }

    void Start()
    {
        _manager = FindObjectOfType<GameManager>();

        Vector3 copyBottomLeft = _camera.ViewportToWorldPoint(new Vector3(0, 0, _camera.nearClipPlane));
        Vector3 copyTopRight = _camera.ViewportToWorldPoint(new Vector3(1, 1, _camera.nearClipPlane));

        _topRight = new Vector2(copyTopRight.x, copyTopRight.y);
        _bottomLeft = new Vector2(copyBottomLeft.x, copyBottomLeft.y);

        {
            //left
            Vector2 position = new Vector2(_bottomLeft.x - 1, 0);
            _left.transform.position = position;
        }

        {
            //right
            Vector2 position = new Vector2(_topRight.x + 1, 0);
            _right.transform.position = position;
        }

        {
            //top
            Vector2 position = new Vector2(0, _topRight.y + 1);
            _top.transform.position = position;
        }

        {
            //bottom
            Vector2 position = new Vector2(0, _bottomLeft.y -1);
            _bottom.transform.position = position;
        }

        {
            //guns
            float diffX = _topRight.x - _bottomLeft.x;
            float diffY = _topRight.y - _bottomLeft.y;

            Vector2 position = new Vector2(0, 0);

            position.x = _bottomLeft.x + diffX / 4;
            position.y = _bottomLeft.y + diffY / 4;

            _gun.transform.position = position;

        }

        _manager.StartGame();
    }
}
