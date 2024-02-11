using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager endManager;
    public bool gameOver;

    private TextMeshProUGUI scoreTextComponent;
    private PanelController panelController;
    private int score;
    [HideInInspector]
    public string lvlUnlock = "LevelUnlock";


    private void Awake()
    {
        if(endManager == null){
        endManager = this;
        DontDestroyOnLoad(gameObject);

        }else{
            Destroy(gameObject);
        }
    }


    public void UpdateScore(int addScore){
        score += addScore;
        scoreTextComponent.text = "Score: "+score.ToString();

    }
    public void StartResovleSequence(){
        StopCoroutine(nameof(ResolveSequence));
        StartCoroutine(ResolveSequence());
    }

    public void ResolveGame(){
        if(gameOver == false){
            WinGame();
        }else{
            LoseGame();
        }
    }


    private IEnumerator ResolveSequence(){
        yield return new WaitForSeconds(2);
        ResolveGame();
    }

    public void WinGame()
    {
        //activate the panel
        //unlock the next level
        //score
        ScoreSet();
        panelController.ActivateWin();
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextLevel>PlayerPrefs.GetInt(lvlUnlock,0)){
            PlayerPrefs.SetInt(lvlUnlock,nextLevel);
        }
    }

    public void LoseGame()
    {
        ScoreSet();
        panelController.ActivateLose();
    }



    public void RegisterPanelController(PanelController pC)
    {
        panelController = pC;
    }

    public void RegisterScoreText(TextMeshProUGUI scoreTextComp){
        scoreTextComponent = scoreTextComp;
    }

    private void ScoreSet(){
        PlayerPrefs.SetInt("Score"+SceneManager.GetActiveScene().name,score);
        int highScore = PlayerPrefs.GetInt("HighScore"+SceneManager.GetActiveScene().name,0);

        if(score>highScore){
            PlayerPrefs.SetInt("HighScore"+SceneManager.GetActiveScene().name,score);
        }
        score = 0;
    }
}
