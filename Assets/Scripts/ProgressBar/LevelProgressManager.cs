using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressManager : MonoBehaviour
{
    public Image[] uiFillImages; // Массив Image для прогресса
    public float[] MaxValue;
    public float maxWidth = 490f; // Максимальная ширина прогресс бара

    public Image[] leftImages; // Массив Image для левых элементов
    public Image[] rightImages; // Массив Image для правых элементов

    private void Start()
    {
        // Проходим по всем прогресс-барам и устанавливаем длину на основе лучших результатов
        for (int i = 0; i < uiFillImages.Length; i++)
        {
            int levelIndex = i + 2; // Индекс уровня для доступа к данным BestResultsManager (2-6)

            if (levelIndex >= 2 && levelIndex <= 6)
            {
                float bestWidth = BestResultsManager.bestWidths[levelIndex - 2]; // Получаем лучшую длину для уровня
                float normalizedWidth = Mathf.Clamp(bestWidth, 0f, maxWidth); // Нормализация `bestWidth` в пределах `maxWidth`
                float progressValue = normalizedWidth / MaxValue[i]; // Пропорциональное значение ширины

                // Устанавливаем пропорциональную длину прогресс-бара
                float newWidth = progressValue * maxWidth;
                uiFillImages[i].rectTransform.sizeDelta = new Vector2(newWidth, uiFillImages[i].rectTransform.sizeDelta.y);

                // Открываем левые элементы если длина не равна 0
                if (newWidth != 0 && i < leftImages.Length)
                {
                    leftImages[i].gameObject.SetActive(true);
                }

                if (RightElementsStateManager.rightElementsState[levelIndex - 2] && i < rightImages.Length)
                {
                    rightImages[i].gameObject.SetActive(true);
                }

            }
        }
    }
}
