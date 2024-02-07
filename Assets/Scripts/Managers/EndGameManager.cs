using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager endManager;
    public bool gameOver;

    private PanelController panelController;

    private void Awake()
    {
        if(endManager == null){
        endManager = this;
        DontDestroyOnLoad(gameObject);

        }else{
            Destroy(gameObject);
        }
    }
    void Start()
    {

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

        panelController.ActivateWin();
    }

    public void LoseGame()
    {
        panelController.ActivateLose();
    }

    public void RegisterPanelController(PanelController pC)
    {
        panelController = pC;
    }
}
