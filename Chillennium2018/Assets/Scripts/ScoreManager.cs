using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScoreManager : MonoBehaviour
{

    private static ScoreManager _instance;

    public static ScoreManager Instance { get { return _instance; } }

    public int player1Score = 0;
    public int player2Score = 0;

    private static bool created = false;

    void Awake()
    {

        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(this.gameObject);
        }


        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake: " + this.gameObject);
        }
    }

    public void AddScore(Controller.ControllerType controllerType)
    {
        if(controllerType == Controller.ControllerType.PLAYER_ONE)
        {
            player1Score += 1000;
        }
        else if(controllerType == Controller.ControllerType.PLAYER_TWO)
        {
            player2Score += 1000;
        }
    }

    public void ResetScore()
    {
        player1Score = 0;
        player2Score = 0;
    }
}
