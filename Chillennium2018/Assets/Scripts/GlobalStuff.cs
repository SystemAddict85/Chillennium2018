using System;

using System.Collections.Generic;
using UnityEngine;

public static class GlobalStuff
{
    private static float originalTimeScale = 1f;
    private static bool isPaused = false;

    public static void PauseGame()
    {
        if (!isPaused) {
            isPaused = true;
            originalTimeScale = Time.timeScale;
            Time.timeScale = 0f;
        }
    }
    public static void UnpauseGame()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = originalTimeScale;            
        }
    }

    public static void FreezeSpawning()
    {
        MonoBehaviour.FindObjectOfType<EnemySpawner>().ToggleSpawning(false);
    }

    public static void FreezeAllMovement()
    {
        foreach(var m in MonoBehaviour.FindObjectsOfType<Movement>())
        {
            m.ToggleMovement(false);
        }
        foreach(var d in MonoBehaviour.FindObjectsOfType<Dashing>())
        {
            d.FinishDash();
        }
    }
    
    public static void UnfreezeAll()
    {
        foreach (var m in MonoBehaviour.FindObjectsOfType<Movement>())
        {
            m.ToggleMovement(true);
        }
    }
    public static void LoseAllControl()
    {
        foreach (var c in MonoBehaviour.FindObjectsOfType<Controller>())
        {
            c.LoseControl();
        }
    }
    public static void RegainAllControl()
    {
        foreach (var c in MonoBehaviour.FindObjectsOfType<Controller>())
        {
            c.GainControl();
        }
    }

    public static void UnfreezeSpawning()
    {
        MonoBehaviour.FindObjectOfType<EnemySpawner>().ToggleSpawning(true);
    }
}

