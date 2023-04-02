using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _GameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        _GameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameOverMenu()
    {
        Time.timeScale= 0f;
        _GameOverPanel.SetActive(true);
    }
}
