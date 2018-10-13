using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{

    public Button endButton;

    void Start()
    {
        endButton = GetComponent<Button>();
        endButton.onClick.AddListener(OnMouseClick);

    }
    public void OnMouseClick()
    {
        SceneManager.LoadScene("GameOver");
    }


}
