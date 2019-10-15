using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance = null;

    public string _server_endpoint = "";

    public int _time_limit = 30;
    public int Time_Limit
    {
        get { return _time_limit; }
    }
    public int _current_best_score = 100;
    public int Best_Score
    {
        get { return _current_best_score; }
    }
    public int _poinst_per_plane = 1;
    
    private int _current_score = 0;
    public int Current_Score
    {
        get { return _current_score; }
    }

    private int _left_time = 0;
    public int Left_Time
    {
        get { return _left_time; }
    }

    public string _menu_scene_name = "Menu";
    public  string _game_scene_name = "Game";

    void Awake()
    {
        //Check if instance already exists
        if (_instance == null)
        {
            //if not, set instance to this
            _instance = this;
        }
        //If instance already exists and it's not this:
        else if (_instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        getConfigurationFromServer();
    }

    private void getConfigurationFromServer()
    {

    }

    public void PlaneHit()
    {
        _current_score += _poinst_per_plane;
        //make the sound
    }

    public void StartGame()
    {
        _current_score = 0;
        _left_time = _time_limit;
        StartCoroutine(WaitTimeCoroutine());
    }

    public void GoToGame()
    {
        SceneManager.LoadScene(_game_scene_name);
    }

    public void EndGame()
    {
        if(_current_score > _current_best_score)
        {
            _current_best_score = _current_score;
        }

        //now we move to the menu scene
        SceneManager.LoadScene(_menu_scene_name);
    }

    IEnumerator WaitTimeCoroutine()
    {
        while(_left_time > 0)
        {
            yield return new WaitForSeconds(1f);//we sleep 1 second
            --_left_time;
        }
        EndGame();
    }
}
