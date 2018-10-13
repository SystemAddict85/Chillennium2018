using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{

    public Button restartButton;

    void Start()
    {
        restartButton = GetComponent<Button>();
        restartButton.onClick.AddListener(OnMouseClick);

    }
    public void OnMouseClick()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
