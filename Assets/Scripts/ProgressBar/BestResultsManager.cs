using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestResultsManager : MonoBehaviour
{
    public static float[] bestWidths = new float[5];

    public static void UpdateBestWidth(int levelIndex, float currentWidth)
    {
        if (levelIndex >= 2 && levelIndex <= 6 && currentWidth > bestWidths[levelIndex - 2])
        {
            bestWidths[levelIndex - 2] = currentWidth; // Обновляем лучший результат для уровня
        }
    }
}
