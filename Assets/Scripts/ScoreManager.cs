using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private int score = 0;

    public void AgregarPuntos(int puntos)
    {
        score += puntos;
        ActualizarScoreText();
    }

    private void ActualizarScoreText()
    {
        scoreText.text = $" {score}";
    }
}