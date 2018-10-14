using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{

    [SerializeField]
    private Player player;
    private int currentHeartHalves;
    private GameObject HeartPanel;
    // Use this for initialization

    public void UpdateHeart()
    {
        HeartPanel = GetComponentInChildren<HorizontalLayoutGroup>().gameObject;
        var hearts = HeartPanel.GetComponentsInChildren<Image>();
        Debug.Log(player.currentHealth);



        if (player.currentHealth % 2 == 1) // half heart
        {
            hearts[player.currentHealth / 2 + 1].fillAmount = .5f;
        }
        else
            hearts[player.currentHealth / 2].fillAmount = 1f;

        for (int i = player.currentHealth / 2; i > 0; i--)
        {
            hearts[i].fillAmount = 1f;
        }

        for (int i = (int)((float)player.currentHealth / 2f + 1.5f); i < hearts.Length; i++)
        {
            hearts[i].fillAmount = 0f;
        }

    }
}
