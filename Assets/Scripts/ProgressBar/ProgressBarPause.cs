using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarPause : MonoBehaviour
{
    public ProgressBar progressBarScript; // ������ �� ������ ProgressBar
    public Image uiFillImagePause; // ������ �� ����������� �������� ���� �����

    public float maxWidthPause = 500; // ������������ ������ �������� ���� �����

    private void Update()
    {
        if (progressBarScript != null && uiFillImagePause != null)
        {
            float currentWidth = progressBarScript.uiFillImage.rectTransform.sizeDelta.x; // �������� ������� ������ ����������� ProgressBar
            float currentHeight = uiFillImagePause.rectTransform.sizeDelta.y; // �������� ������� ������ ����������� ProgressBarPause

            float progressValue = currentWidth / progressBarScript.maxWidth; // ������������ �������� ����� ������������ ��������� ��������� ����
            float newWidthPause = progressValue * maxWidthPause; // ������������� ���������������� �������� ��� �������� ���� �����

            uiFillImagePause.rectTransform.sizeDelta = new Vector2(newWidthPause, currentHeight); // ������������� ���������������� ����� ��� ProgressBarPause
        }
        else
        {
            Debug.LogWarning("ProgressBar script reference or uiFillImagePause is missing!"); // ��������������, ���� ������ �� ������ ProgressBar ��� uiFillImagePause �����������
        }
    }
}
