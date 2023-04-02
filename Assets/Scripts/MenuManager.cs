using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private AudioSource buttonClickSound;

    public void PlayButton()
    {
        buttonClickSound.Play();
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitButton()
    {
        buttonClickSound.Play();
        Application.Quit();
    }
}
