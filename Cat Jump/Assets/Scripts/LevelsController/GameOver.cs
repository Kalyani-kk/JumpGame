using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private Button _playAgainBtn;
    [SerializeField]
    private TMP_Text _gameOverText;

    private void Awake()
    {
        _gameOverText.enabled = false;
    }


    
}
