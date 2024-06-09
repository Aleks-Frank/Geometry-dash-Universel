using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberImageController : MonoBehaviour
{
    public GameObject numberImagesParent; // GameObject с числами от 0 до 9
    public int numberToDisplay = 0; // Число для отображения

    private string distans = 0 + "(единицы)";

    public void ShowNumberImage()
    {
        // Отключаем все объекты с числами
        foreach (Transform child in numberImagesParent.transform)
        {
            child.gameObject.SetActive(false);
        }

        // Включаем объект с соответствующим числом
        Transform numberImage = numberImagesParent.transform.Find(distans);
        if (numberImage != null)
        {
            numberImage.gameObject.SetActive(true);
        }
    }
}
