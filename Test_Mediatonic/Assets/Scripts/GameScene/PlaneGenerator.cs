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
        _currentPlanesAlive = 1; Random.Range(3,5);

        GameObject plane;
        if (_pool.getItem(out plane))
        {
            Vector2 position = new Vector2(0, 0);
            position.x = -8;
            position.y = 0;
            plane.transform.position = position;
            plane.SetActive(true);
        }

        /*
		for(int i = 0; i < _currentPlanesAlive; ++i)
		{
			GameObject plane;
			if(_pool.getItem(out plane))
			{
				Vector2 position = new Vector2(0,0);
                position.x = _startManager.TopLeft.x;
                position.y = _startManager.TopLeft.y + 1 - i;
                plane.transform.position = position;
                plane.SetActive(true);
            }
		}
        */
    }
}
