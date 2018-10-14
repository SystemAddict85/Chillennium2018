using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashScreenUI : MonoBehaviour {

    private static FlashScreenUI _instance;

    public static FlashScreenUI Instance { get { return _instance; } }

    private Image image;

    [SerializeField]
    private Color[] colors;

    private float interval;

    private bool isFlashing;

    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }else if (_instance != this)
        {
            Destroy(this.gameObject);
        }

        image = GetComponent<Image>();
    }

    private void Update()
    {
        if (isFlashing)
        {
            var color = image.color;
            color.a += Time.deltaTime * interval;
            image.color = color;
            if(color.a >= 1f)
            {
                isFlashing = false;
                DeactivateScreen();
            }
        }
    }

    private void DeactivateScreen()
    {
        var color = image.color;
        color.a = 0f;
        image.color = color;
        image.enabled = false;
    }
    public void FlashScreen(int colorIndex, float duration = 5f)
    {
        if (!isFlashing)
        {
            interval = 1f/duration;

            var color = image.color;
            color = colors[colorIndex];
            color.a = 0f;
            image.color = color;
            image.enabled = true;

            isFlashing = true;

        }
        else
        {
            Debug.Log("Already flashing");
        }
    }   
}
