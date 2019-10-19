using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance = null;
    public static GameManager Instance
    {
        get { return _instance; }
    }
    #endregion

    #region Sound
    private AudioSource _audioSource;
    public AudioClip _explosion_sound;
    #endregion

    #region Downloaded data
    [SerializeField]
    private string _server_endpoint = "";

    [SerializeField]
    private int _time_limit = 30;
    public int Time_Limit
    {
        get { return _time_limit; }
    }

    [SerializeField]
    private int _current_best_score = 100;
    public int Best_Score
    {
        get { return _current_best_score; }
    }

    [SerializeField]
    private int _poinst_per_plane = 1;

    [SerializeField]
    private int _current_score = 0;
    public int Current_Score
    {
        get { return _current_score; }
    }

    [SerializeField]
    private int _left_time_in_game = 0;
    public int Left_Time
    {
        get { return _left_time_in_game; }
    }
    #endregion

    private string _menu_scene_name = "Menu";
    private string _game_scene_name = "Game";

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
            return;
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //get the data from de darpa-net ;)
        StartCoroutine(getConfigurationFromServer());

        //get the component so we dont need to do the getcomponent all the time
        _audioSource = GetComponent<AudioSource>();
    }
    #region Download data
    class DataFromJSON
    {
        //we set the variables to the default values, so if the json is bad, but there is data, nothing is corrupted
        public int time_limit = 30;
        public int default_high_score = 100;
        public int points_per_plane = 1;
        public string id = "";
    }
    /// <summary>
    /// This method tries to connect to the url given.
    /// If there is success, it converts the data downloaded to a temporaly class using the Unity JSON parser, and then configure the Game.
    /// If there is any fail, it returns and nothing is changed.
    /// </summary>
    /// <returns></returns>
    IEnumerator getConfigurationFromServer()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(_server_endpoint))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                //here there is some problem-
                //in this case, we dont do anything
                Debug.Log("Can't connect to server, using default values");
            }
            else
            {
                string txt = webRequest.downloadHandler.text;
                DataFromJSON data = JsonUtility.FromJson<DataFromJSON>(txt);

                _time_limit = data.time_limit;
                _current_best_score = data.default_high_score;
                _poinst_per_plane = data.points_per_plane;
            }
        }
    }
    #endregion

    /// <summary>
    /// We call this method any time there is a plane and bullet collision
    /// </summary>
    public void PlaneHit()
    {
        //increase the score
        _current_score += _poinst_per_plane;
        //make the sound
        _audioSource.PlayOneShot(_explosion_sound);
    }

    /// <summary>
    /// We call this method any time we want to start the game
    /// </summary>
    public void StartGame()
    {
        _current_score = 0;//set the current points to 0
        _left_time_in_game = _time_limit;//set the left time to the start time
        StartCoroutine(WaitTimeCoroutine());//launch a coroutine that controls the game time
    }

    /// <summary>
    /// We call this method from the Menu scene so we can go to the game scene
    /// </summary>
    public void GoToGame()
    {
        SceneManager.LoadScene(_game_scene_name);
    }

    /// <summary>
    /// We call this method from the Time coroutine so we update the best score and we go to the menu scene
    /// </summary>
    public void EndGame()
    {
        //update the current best score
        if(_current_score > _current_best_score)
        {
            _current_best_score = _current_score;
        }

        //now we move to the menu scene
        SceneManager.LoadScene(_menu_scene_name);
    }

    /// <summary>
    /// Coroutine that controls the time of the game
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitTimeCoroutine()
    {
        while(_left_time_in_game > 0)
        {
            yield return new WaitForSeconds(1f);//we sleep 1 second
            --_left_time_in_game;
        }
        //here there is no more time left, so the game is ended.
        EndGame();
    }
}
