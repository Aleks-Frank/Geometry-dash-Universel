using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressManager : MonoBehaviour
{
    public Image[] uiFillImages; // ������ Image ��� ���������
    public float[] MaxValue;
    public float maxWidth = 490f; // ������������ ������ �������� ����

    public Image[] leftImages; // ������ Image ��� ����� ���������
    public Image[] rightImages; // ������ Image ��� ������ ���������

    private void Start()
    {
        // �������� �� ���� ��������-����� � ������������� ����� �� ������ ������ �����������
        for (int i = 0; i < uiFillImages.Length; i++)
        {
            int levelIndex = i + 2; // ������ ������ ��� ������� � ������ BestResultsManager (2-6)

            if (levelIndex >= 2 && levelIndex <= 6)
            {
                float bestWidth = BestResultsManager.bestWidths[levelIndex - 2]; // �������� ������ ����� ��� ������
                float normalizedWidth = Mathf.Clamp(bestWidth, 0f, maxWidth); // ������������ `bestWidth` � �������� `maxWidth`
                float progressValue = normalizedWidth / MaxValue[i]; // ���������������� �������� ������

                // ������������� ���������������� ����� ��������-����
                float newWidth = progressValue * maxWidth;
                uiFillImages[i].rectTransform.sizeDelta = new Vector2(newWidth, uiFillImages[i].rectTransform.sizeDelta.y);

                // ��������� ����� �������� ���� ����� �� ����� 0
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
