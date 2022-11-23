using System;
using TMPro;
using UnityEngine;

namespace Code
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private string _scoreFormat = "Score: {0}";
        private int _score;
        
        public void AddPoint(int amount)
        {
            _score+=amount;
            UpdateView(_score);
        }

        private void UpdateView(int score)
        {
            _scoreText.text = string.Format(_scoreFormat, score);
        }
    }
}