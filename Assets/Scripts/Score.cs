using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private AudioSource goalAudio;
    private Text scoreText;
    private int score;
    private void Awake()
    {
        goalAudio = GetComponent<AudioSource>();
        scoreText = GetComponentInChildren<Text>();
        scoreText.text = score.ToString();
        EventManager.GoalEvent += Goal;
    }
    private void Goal()
    {
        goalAudio.Play();
        score++;
        scoreText.text = score.ToString();
    }
    private void OnDestroy()
    {
        EventManager.GoalEvent -= Goal;
    }
}
