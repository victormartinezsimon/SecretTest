using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerMenu : MonoBehaviour
{
    private GameManager _manager;
    public Text _high_score;
    public Text _current_score;

    void Start()
    {
        _manager = GameManager.Instance;

        //if there is current score, we change the string and make visible
        //if there is no current score(score to 0), we dont change the string and make invisible
        if(_manager.Current_Score > 0)
        {
            _current_score.text = "Last Score: " + _manager.Current_Score.ToString();
            _current_score.enabled = false;
        }
        else
        {
            _current_score.enabled = false;
        }

        _high_score.text = "High Score: " + _manager.Best_Score.ToString();
    }

    /// <summary>
    /// We call this method from the UI so we can start the Game
    /// </summary>
    public void OnButtonPress()
    {
        _manager.GoToGame();
    }
}
