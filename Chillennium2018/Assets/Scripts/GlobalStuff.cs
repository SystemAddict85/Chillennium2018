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
}

