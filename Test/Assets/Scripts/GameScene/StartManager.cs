using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
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
        Vector3 copyBottomLeft = _camera.ViewportToWorldPoint(new Vector3(0, 0, _camera.nearClipPlane));//we get the bottom left screen point to world coordinates 
        Vector3 copyTopRight = _camera.ViewportToWorldPoint(new Vector3(1, 1, _camera.nearClipPlane));//we get the top right screen point to world coordinates

        _topRight = new Vector2(copyTopRight.x, copyTopRight.y);//we save the data to a Vector2
        _bottomLeft = new Vector2(copyBottomLeft.x, copyBottomLeft.y);

        {
            //we meve the left collider to the correct position
            Vector2 position = new Vector2(_bottomLeft.x - 1, 0);
            _left.transform.position = position;
        }

        {
            //we meve the right collider to the correct position
            Vector2 position = new Vector2(_topRight.x + 1, 0);
            _right.transform.position = position;
        }

        {
            //we meve the top collider to the correct position
            Vector2 position = new Vector2(0, _topRight.y + 1);
            _top.transform.position = position;
        }

        {
            //we meve the bottom collider to the correct position
            Vector2 position = new Vector2(0, _bottomLeft.y -1);
            _bottom.transform.position = position;
        }

        {
            //guns
            float diffX = _topRight.x - _bottomLeft.x;//this is the width in real world coordinates
            float diffY = _topRight.y - _bottomLeft.y;//this is the height in real world coordinates

            //we move the gun to the correct position
            Vector2 position = new Vector2(_bottomLeft.x + diffX / 4, _bottomLeft.y + diffY / 4);

            _gun.transform.position = position;
        }
        //we notify the GameNanager that everything is in the correct position, so the game can start
        GameManager.Instance.StartGame();
    }
}
