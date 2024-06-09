using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarPause : MonoBehaviour
{
    public ProgressBar progressBarScript; // Ссылка на скрипт ProgressBar
    public Image uiFillImagePause; // Ссылка на изображение прогресс бара паузы

    public float maxWidthPause = 500; // Максимальная ширина прогресс бара паузы

    private void Update()
    {
        if (progressBarScript != null && uiFillImagePause != null)
        {
            float currentWidth = progressBarScript.uiFillImage.rectTransform.sizeDelta.x; // Получаем текущую ширину изображения ProgressBar
            float currentHeight = uiFillImagePause.rectTransform.sizeDelta.y; // Получаем текущую высоту изображения ProgressBarPause

            float progressValue = currentWidth / progressBarScript.maxWidth; // Рассчитываем прогресс паузы относительно прогресса основного бара
            float newWidthPause = progressValue * maxWidthPause; // Устанавливаем пропорциональное значение для прогресс бара паузы

            uiFillImagePause.rectTransform.sizeDelta = new Vector2(newWidthPause, currentHeight); // Устанавливаем пропорциональную длину для ProgressBarPause
        }
        else
        {
            Debug.LogWarning("ProgressBar script reference or uiFillImagePause is missing!"); // Предупреждение, если ссылка на скрипт ProgressBar или uiFillImagePause отсутствует
        }
    }
}
