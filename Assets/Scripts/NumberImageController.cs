using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberImageController : MonoBehaviour
{
    public GameObject numberImagesParent; // GameObject � ������� �� 0 �� 9
    public int numberToDisplay = 0; // ����� ��� �����������

    private string distans = 0 + "(�������)";

    public void ShowNumberImage()
    {
        // ��������� ��� ������� � �������
        foreach (Transform child in numberImagesParent.transform)
        {
            child.gameObject.SetActive(false);
        }

        // �������� ������ � ��������������� ������
        Transform numberImage = numberImagesParent.transform.Find(distans);
        if (numberImage != null)
        {
            numberImage.gameObject.SetActive(true);
        }
    }
}
