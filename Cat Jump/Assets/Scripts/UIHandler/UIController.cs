using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public static UIController instance;
    [SerializeField]
    private GameObject _startGamePanel;
    [SerializeField]
    private Button _playButton;

    [SerializeField]
    GameObject _player;
    delegate void NewDelegate();
    NewDelegate newDelegate;

    private void Awake()
    {
        if(instance!= null)
        {
            Debug.Log("Instance");
        } else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        _player.SetActive(false);
    }

    private void Start()
    {
        _playButton.onClick.AddListener(()=> PlayGame());
    }


    private void PlayGame()
    {
        _startGamePanel.SetActive(false);
        _player.SetActive(true);
    }



}
