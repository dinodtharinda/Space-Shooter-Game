using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager endManager;
    public bool gameOver;

    private PanelController panelController;
    private TextMeshProUGUI scoreTextConmponent;
    private int score;
    [HideInInspector]
    public string lvlUnlock = "LevelUnlock";
    private void Awake()
    {
        if (endManager == null)
        {
            endManager = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void StartResolveSequence()
    {
        StopCoroutine(nameof(ResolveSequence));
        StartCoroutine(ResolveSequence());
    }
    private IEnumerator ResolveSequence()
    {
        yield return new WaitForSeconds(2);
        ResolveGame();
    }
    void Start()
    {

    }
    public void UpdateScore(int addScore)
    {
        score += addScore;
        scoreTextConmponent.text = "Score: " + score.ToString();
    }
    public void ResolveGame()
    {
        if (gameOver == false)
        {
            WinGame();
        }
        else
        {
            LoseGame();
        }
    }
    public void WinGame()
    {

        ScoreSet();
      
        panelController.ActivateWin();
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevel > PlayerPrefs.GetInt(lvlUnlock, 0))
        {
            PlayerPrefs.SetInt(lvlUnlock, nextLevel);
        }
    }

    public void LoseGame()
    {
        ScoreSet();
       
        panelController.ActivateLose();
    }

    private void ScoreSet()
    {
        PlayerPrefs.SetInt("Score" + SceneManager.GetActiveScene().name, score);
        int highScore = PlayerPrefs.GetInt("HighScore" + SceneManager.GetActiveScene().name, 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore" + SceneManager.GetActiveScene().name, score);
            score = 0;
        }
    }

    public void RegisterPanelController(PanelController pC)
    {
        panelController = pC;
    }
    public void RegisterScoreText(TextMeshProUGUI scoreTextComp)
    {
        scoreTextConmponent = scoreTextComp;
    }
}
