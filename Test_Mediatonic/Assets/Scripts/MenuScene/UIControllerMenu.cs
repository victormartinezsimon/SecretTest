using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerMenu : MonoBehaviour
{
    private GameManager _manager;
    public Text _high_score;
    public Text _current_score;

    // Start is called before the first frame update
    void Start()
    {
        _manager = FindObjectOfType<GameManager>();

        if(_manager.Current_Score > 0)
        {
            _current_score.text = "Last Score: " + _manager.Current_Score.ToString();
        }
        else
        {
            _current_score.enabled = false;
        }

        _high_score.text = "High Score: " + _manager.Best_Score.ToString();

    }

    public void onButtonPress()
    {
        _manager.GoToGame();
    }
}
