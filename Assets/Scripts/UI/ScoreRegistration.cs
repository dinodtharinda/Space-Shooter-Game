using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreRegistration : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI textforRegistration = GetComponent<TextMeshProUGUI>();
        EndGameManager.endManager.RegisterScoreText(textforRegistration);
        textforRegistration.text = "Score: 0";
    }

    
}
