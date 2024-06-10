using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressImagesController : MonoBehaviour
{
    public Image progressBar; // Ссылка на объект Image полоски прогресса
    public GameObject[] numberImages; // Массив объектов с картинками чисел от 0 до 9
    public int levelIndex;

    public float maxWidth = 180; // Максимальная ширина полоски
    private float currentWidth; // Текущая ширина полоски

    

    void Update()
    {
        currentWidth = progressBar.rectTransform.sizeDelta.x; // Получаем текущую ширину полоски
        float percentage = (currentWidth / maxWidth) * 100f; // Вычисляем процент от максимальной ширины

        int tensDigit = Mathf.FloorToInt(percentage / 10); // Получаем десятки
        int onesDigit = Mathf.FloorToInt(percentage) % 10; // Получаем единицы

        Debug.Log("Percentage: " + percentage + "% | Tens: " + tensDigit + " | Ones: " + onesDigit);

        ShowNumberImages(tensDigit, onesDigit); // Открываем соответствующие картинки
    }

    void ShowNumberImages(int tens, int ones)
    {
        for (int i = 0; i < numberImages.Length; i++)
        {
            numberImages[i].SetActive(false); // Скрываем все картинки
        }

        if (RightElementsStateManager.rightElementsState[levelIndex - 2])
        {
            numberImages[1].SetActive(true); // Открываем картинку с 1 (десятичная)
            numberImages[0].SetActive(true); // Открываем картинку с 0 (десятичный)
            numberImages[10].SetActive(true); // Открываем картинку с 0 (единицы)
        }
        else
        {
            if (tens > 0 && ones >= 0)
            {
                numberImages[tens].SetActive(true); // Открываем картинку с десятками
                numberImages[ones + 10].SetActive(true); // Открываем картинку с единицами (10 - это сдвиг для единиц)
            }
            else if (tens == 0 && ones > 0)
            {
                numberImages[ones + 10].SetActive(true); // Открываем картинку с единицами (10 - это сдвиг для единиц)
            }
            else
            {
                numberImages[10].SetActive(true); // Открываем картинку с 0 (единицы)
            }
        }
    }
}
