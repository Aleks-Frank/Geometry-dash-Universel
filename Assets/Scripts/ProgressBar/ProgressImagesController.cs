using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressImagesController : MonoBehaviour
{
    public Image progressBar; // ������ �� ������ Image ������� ���������
    public GameObject[] numberImages; // ������ �������� � ���������� ����� �� 0 �� 9
    public int levelIndex;

    public float maxWidth = 180; // ������������ ������ �������
    private float currentWidth; // ������� ������ �������

    

    void Update()
    {
        currentWidth = progressBar.rectTransform.sizeDelta.x; // �������� ������� ������ �������
        float percentage = (currentWidth / maxWidth) * 100f; // ��������� ������� �� ������������ ������

        int tensDigit = Mathf.FloorToInt(percentage / 10); // �������� �������
        int onesDigit = Mathf.FloorToInt(percentage) % 10; // �������� �������

        Debug.Log("Percentage: " + percentage + "% | Tens: " + tensDigit + " | Ones: " + onesDigit);

        ShowNumberImages(tensDigit, onesDigit); // ��������� ��������������� ��������
    }

    void ShowNumberImages(int tens, int ones)
    {
        for (int i = 0; i < numberImages.Length; i++)
        {
            numberImages[i].SetActive(false); // �������� ��� ��������
        }

        if (RightElementsStateManager.rightElementsState[levelIndex - 2])
        {
            numberImages[1].SetActive(true); // ��������� �������� � 1 (����������)
            numberImages[0].SetActive(true); // ��������� �������� � 0 (����������)
            numberImages[10].SetActive(true); // ��������� �������� � 0 (�������)
        }
        else
        {
            if (tens > 0 && ones >= 0)
            {
                numberImages[tens].SetActive(true); // ��������� �������� � ���������
                numberImages[ones + 10].SetActive(true); // ��������� �������� � ��������� (10 - ��� ����� ��� ������)
            }
            else if (tens == 0 && ones > 0)
            {
                numberImages[ones + 10].SetActive(true); // ��������� �������� � ��������� (10 - ��� ����� ��� ������)
            }
            else
            {
                numberImages[10].SetActive(true); // ��������� �������� � 0 (�������)
            }
        }
    }
}
