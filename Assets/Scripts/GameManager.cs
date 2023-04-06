using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _GameOverPanel;

    [Header("EventManager parameter")]
    [SerializeField] private EventManager eventManager;

    public GameObject GameOverPanel { get => _GameOverPanel; set => _GameOverPanel = value; }

    // Start is called before the first frame update
    void Start()
    {

        _GameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameOverMenu()
    {
        Time.timeScale= 0f;
        eventManager.EventList.Clear();
        _GameOverPanel.SetActive(true);
    }

    public void Menuload()
    {
        SceneManager.LoadScene("Menu");
    }
}
