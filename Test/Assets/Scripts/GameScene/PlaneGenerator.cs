using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneGenerator : MonoBehaviour
{
	public StartManager _startManager;
	private GameManager _manager;
	private PoolManager _pool;
	private int _currentPlanesAlive;

	void Start()
	{
		_manager = GameManager._instance;
        _pool = GetComponent<PoolManager>();
        _startManager = FindObjectOfType<StartManager>();

        Random.InitState(42);
		GeneratePlanes();
	}

	public void PlaneDestroyed()
	{
		//we notify the gamemanager
		 GameManager._instance.PlaneHit();

		 //we update the current planes alive
		 --_currentPlanesAlive;

		 if(_currentPlanesAlive == 0)
		 {
		 	GeneratePlanes();
		 }
	}

	public void GeneratePlanes()
	{
        _currentPlanesAlive = Random.Range(3,5);

        float _total_diff = _startManager.TopRight.y - _startManager.BottomLeft.y;

        float _diff_between_planes = _total_diff / 10;

        float first_plane_y = _startManager.BottomLeft.y + _total_diff / 2;

        for (int i = 0; i < _currentPlanesAlive; ++i)
		{
			GameObject plane;
			if(_pool.getItem(out plane))
			{
                Vector2 position = new Vector2(_startManager.BottomLeft.x, first_plane_y + _diff_between_planes * i);
                plane.transform.position = position;
                plane.SetActive(true);
                plane.GetComponent<LinearMovement>()._velocity = Random.Range(2, 5);
            }
		}
    }
}
