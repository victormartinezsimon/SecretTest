using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerGame : MonoBehaviour
{
    private GameManager _manager;
    public Text _current_score;
    public Text _current_time;
    public Text _best_Score;

    void Start()
    {
        _manager = FindObjectOfType<GameManager>();
        _best_Score.text = _manager.Best_Score.ToString();
    }

    void Update()
    {
        _current_score.text = _manager.Current_Score.ToString();
        _current_time.text = _manager.Left_Time.ToString();
    }
}
