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
        _manager = GameManager.Instance;
        //we set the best score in the start because it wont be changed
        _best_Score.text = _manager.Best_Score.ToString();
    }

    void Update()
    {
        //in every frame, we update the current score and the left time
        _current_score.text = _manager.Current_Score.ToString();
        _current_time.text = _manager.Left_Time.ToString();
    }
}
