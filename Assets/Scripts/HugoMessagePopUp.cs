using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HugoMessagePopUp : MonoBehaviour
{
    [SerializeField] GameObject _gameOverPanel;
    [SerializeField] GameObject _HugomessagePanel;
    [SerializeField] ParticleSystem _particles;
    [Header("Messages")]
    [SerializeField] GameObject _message_1;
    [SerializeField] GameObject _message_2;
    [SerializeField] GameObject _message_3;
    [SerializeField] GameObject _message_4;
    [SerializeField] GameObject _message_5;
    [SerializeField] GameObject _message_6;
    [SerializeField] GameObject _message_7;
    [SerializeField] GameObject _message_8;
    [SerializeField] GameObject _message_9;
    [SerializeField] GameObject _message_10;
    [SerializeField] GameObject _message_11;
    [SerializeField] GameObject _message_12;
    [SerializeField] GameObject _message_13;

    private int _paneltoplay;
    private bool _readyToRead = true;
    private bool _nextOk = true;

    // Start is called before the first frame update
    void Start()
    {
        _HugomessagePanel.SetActive(true);
        _particles.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(_gameOverPanel.activeSelf == true || Time.timeScale == 0)
        {
            _HugomessagePanel.SetActive(false);
            _particles.Stop();
        }
        else if (_nextOk)
        {
            _HugomessagePanel.SetActive(true);
            StartCoroutine(NextMessage());
            _particles.Play();
        }
        else
        {
            _HugomessagePanel.SetActive(true);
            _particles.Play();
        }
            
    }
  

    IEnumerator NextMessage()
    {
        Debug.Log("nextok");
        _nextOk = false;
        _paneltoplay = Random.Range(1, 14);

        switch (_paneltoplay)
        {
            case 1:
                _message_1.SetActive(true);
                StartCoroutine(TimeForRead()); 
                break;
            case 2:
                _message_2.SetActive(true);
                StartCoroutine(TimeForRead());
                break;
            case 3:
                _message_3.SetActive(true);
                StartCoroutine(TimeForRead());
                break;
            case 4:
                _message_4.SetActive(true);
                StartCoroutine(TimeForRead());
                break;
            case 5:
                _message_5.SetActive(true);
                StartCoroutine(TimeForRead());
                break;
            case 6:
                _message_6.SetActive(true);
                StartCoroutine(TimeForRead());
                break;
            case 7:
                _message_7.SetActive(true);
                StartCoroutine(TimeForRead());
                break;
            case 8:
                _message_8.SetActive(true);
                StartCoroutine(TimeForRead());
                break;
            case 9:
                _message_9.SetActive(true);
                StartCoroutine(TimeForRead());
                break;
            case 10:
                _message_10.SetActive(true);
                StartCoroutine(TimeForRead());
                break;
            case 11:
                _message_11.SetActive(true);
                StartCoroutine(TimeForRead());
                break;
            case 12:
                _message_12.SetActive(true);
                StartCoroutine(TimeForRead());
                break;
            case 13:
                _message_13.SetActive(true);
                StartCoroutine(TimeForRead());
                break;
        }
        yield return new WaitForSeconds(20f);
        _nextOk = true;
    }

    IEnumerator TimeForRead()
    {
        Debug.Log("timereadok");
        yield return new WaitForSeconds(5f);
        _message_1.SetActive(false);
        _message_2.SetActive(false);
        _message_3.SetActive(false);
        _message_4.SetActive(false);
        _message_5.SetActive(false);
        _message_6.SetActive(false);
        _message_7.SetActive(false);
        _message_8.SetActive(false);
        _message_9.SetActive(false);
        _message_10.SetActive(false);
        _message_11.SetActive(false);
        _message_12.SetActive(false);
        _message_13.SetActive(false);

    }
}
