using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToStart : MonoBehaviour
{
    public Vector3 startPosition;
    public Transform endLine; // ��������� ���������� endLine

    void Start()
    {
        startPosition = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tilemap2Collider"))
        {
            // �������� ������� ��������
            float currentProgress = CalculateProgress();

            // �������� ������ �������� �� BestResultsManager
            float bestProgress = BestResultsManager.bestWidths[SceneManager.GetActiveScene().buildIndex - 2];

            // ���������� ������� �������� � ������
            if (currentProgress > bestProgress)
            {
                // ��������� ������ ��������
                BestResultsManager.UpdateBestWidth(SceneManager.GetActiveScene().buildIndex, currentProgress);
            }

            // ��������� ����� ������
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
        }
    }

    float CalculateProgress()
    {
        if (endLine != null)
        {
            float currentDistance = Vector3.Distance(transform.position, startPosition);
            float totalDistance = Vector3.Distance(startPosition, endLine.position);

            // ������������ ��������� � �������� �� 0 �� 1
            float progress = Mathf.Clamp01(currentDistance / totalDistance);
            return progress;
        }

        return 0f;
    }
}
