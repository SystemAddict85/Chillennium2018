using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

    public Button startButton;

    void Start()
    {
        startButton = GetComponent<Button>();
        startButton.onClick.AddListener(OnMouseClick);

    }
    public void OnMouseClick()
    {
        SceneManager.LoadScene("MainGame");
    }


}
