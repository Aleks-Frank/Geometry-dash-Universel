using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProgressBar : MonoBehaviour
{
    [Header("UI references:")]
    [SerializeField] public Image uiFillImage;

    [Header("Player & Endline references:")]
    [SerializeField] private Transform player;
    [SerializeField] private Transform endLine;

    public int sceneIndex; // Индекс сцены для прогресс бара

    private Vector3 endLinePosition;

    public int maxWidth = 760;
    private float fullDistance;

    private void Start()
    {
        endLinePosition = endLine.position;
        fullDistance = GetDistance();
    }

    private float GetDistance()
    {
        return Vector3.Distance(player.position, endLinePosition);
    }

    private void UpdateProgressWidth(float value)
    {
        float currentWidth = value * maxWidth;
        float currentHeight = uiFillImage.rectTransform.sizeDelta.y;
        uiFillImage.rectTransform.sizeDelta = new Vector2(currentWidth, currentHeight);

        BestResultsManager.UpdateBestWidth(sceneIndex, currentWidth);
    }

    private void Update()
    {
        float newDistance = GetDistance();
        float progressValue = Mathf.InverseLerp(fullDistance, 0f, newDistance);

        UpdateProgressWidth(progressValue);
    }
}
