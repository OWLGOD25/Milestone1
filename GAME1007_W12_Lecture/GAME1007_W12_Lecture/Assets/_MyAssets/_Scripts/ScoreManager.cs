using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    
        public TextMeshProUGUI scoreText; // Reference to the TMP text component
        private int score = 0; // Initialize score

        private void Start()
        {
            UpdateScoreText(); // Update the text at the start
        }

        public void AddScore(int points)
        {
            score += points; // Add points to the score
            UpdateScoreText(); // Update the displayed score
        }

        private void UpdateScoreText()
        {
            scoreText.text = "Score: " + score; // Update the TMP text
        }
    }   

