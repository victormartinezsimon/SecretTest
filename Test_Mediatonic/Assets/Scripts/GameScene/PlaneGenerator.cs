using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneGenerator : MonoBehaviour
{
	public GameStart _gameStart;
	private GameManager _manager;
	private PoolManager _pool;
	private int _currentPlanesAlive;

	void Start()
	{
		_manager = GameManager._instance;
		_pool = getComponent<PoolManager>();
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
				position.x = _gameStart.
			}
		}
	}
}
