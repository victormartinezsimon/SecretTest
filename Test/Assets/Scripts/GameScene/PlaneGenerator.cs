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
		_manager = GameManager.Instance;
        _pool = GetComponent<PoolManager>();

        Random.InitState((int)Time.realtimeSinceStartup);//we initializate the random 
		GeneratePlanes();//the first time, we generate some planes
	}

    /// <summary>
    /// This method is called any time there is a collision between a plane and a bullet
    /// </summary>
	public void PlaneDestroyed()
	{
		//we notify the gamemanager that there is a collision, so the score can be increased
		 _manager.PlaneHit();

		 //we update the current planes alive
		 --_currentPlanesAlive;

         //if there is no more planes alive, that means that we need to generate move planes
		 if(_currentPlanesAlive == 0)
		 {
		 	GeneratePlanes();
		 }
	}

    /// <summary>
    /// this method generate random planes
    /// For each plane, change the position to a random value
    /// Also change the velocity to a random value
    /// with this two randoms, every play is different
    /// </summary>
	public void GeneratePlanes()
	{
        //we get the random number of planes
        //the range is for integer numbers, so the max limit is not included. This is the reason why the random is 3-6 and not 3-5
        _currentPlanesAlive = 5;
        //Random.Range(3,6);//random to generate the number of planes
        

        float _total_diff = _startManager.TopRight.y - _startManager.BottomLeft.y; //total Height in world coordinates

        float _diff_between_planes = _total_diff / 10;//this is the Y difference between planes

        float first_plane_y = _startManager.BottomLeft.y + _total_diff / 2; //the planes minimun Y will be the half of the screen

        for (int i = 0; i < _currentPlanesAlive; ++i)
		{
			GameObject plane = null;
			if(_pool.GetItem(out plane))
			{
                float startX = _startManager.BottomLeft.x - Random.Range(0f, 4f);//the plane will start from the limit left of the screen and limit left -4 
                float startY = first_plane_y + _diff_between_planes * i;
                Vector2 position = new Vector2(startX, startY);
                plane.transform.position = position;
                plane.SetActive(true);
            }
		}
    }
}
