using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{
    public GameObject winPanel;
    public Image uiEndImage;
    public int levelIndex; // �������, ��� �������� ����������� ������ �������

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            winPanel.SetActive(true);
            uiEndImage.gameObject.SetActive(true);
            RightElementsStateManager.rightElementsState[levelIndex - 2] = true; // ������������� ��������� ������� ��������
            Time.timeScale = 0;
        }
    }
}
