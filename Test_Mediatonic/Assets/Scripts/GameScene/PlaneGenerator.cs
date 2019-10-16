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
		_pool = getComponent<PoolManager>();
        _startManager = FindObjectsOfType<StartManager>();

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

		for(int i = 0; i < _currentPlanesAlive; ++i)
		{
			GameObject plane;
			if(_pool.getItem(out plane))
			{
				Vector2 position = new Vector2(0,0);
                position.x = _startManager.TopLeft.x;
                position.y = Random.Range(_startManager.BottomRight.y - 1, _startManager.TopLeft.y + 1);
                plane.transform.position = position;
            }
		}
	}
}
