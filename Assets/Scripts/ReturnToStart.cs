using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToStart : MonoBehaviour
{
    public Vector3 startPosition;
    public Transform endLine; // Добавляем переменную endLine

    void Start()
    {
        startPosition = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tilemap2Collider"))
        {
            // Получаем текущий прогресс
            float currentProgress = CalculateProgress();

            // Получаем лучший прогресс из BestResultsManager
            float bestProgress = BestResultsManager.bestWidths[SceneManager.GetActiveScene().buildIndex - 2];

            // Сравниваем текущий прогресс с лучшим
            if (currentProgress > bestProgress)
            {
                // Обновляем лучший прогресс
                BestResultsManager.UpdateBestWidth(SceneManager.GetActiveScene().buildIndex, currentProgress);
            }

            // Загружаем сцену заново
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

            // Нормализация прогресса в пределах от 0 до 1
            float progress = Mathf.Clamp01(currentDistance / totalDistance);
            return progress;
        }

        return 0f;
    }
}
