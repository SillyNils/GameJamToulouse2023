using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEAreaDectection : MonoBehaviour
{
    //private bool _EnterDetected = false;

    [SerializeField] GameObject _Qtesprite1;
    [SerializeField] GameObject _Qtesprite2;
    [SerializeField] GameObject _Qtesprite3;
    [SerializeField] GameObject _Qtesprite4;

    private bool _TimerOff;

    private int _RandQTE;
    // Start is called before the first frame update
    void Start()
    {
        _Qtesprite1.SetActive(false);
        _Qtesprite2.SetActive(false);
        _Qtesprite3.SetActive(false);
        _Qtesprite4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {


        _RandQTE = 1;//Random.Range(1,4);

    if(_RandQTE == 1)
        {
            _Qtesprite1.SetActive(true);
            if (Input.GetKeyDown("joystick button 0"))
            {
                //condition reset perso
                Debug.Log("victoire QTE");
                StartCoroutine(QteTimer());
            }
            else if (_TimerOff)
            {
                _Qtesprite1.SetActive(false);
                GameOver();
            }
        }
    else if(_RandQTE == 2)
        {
            _Qtesprite2.SetActive(true);
            if (Input.GetKeyDown("joystick button 1"))
            {
                //condition reset perso
                Debug.Log("victoire QTE");
                StartCoroutine(QteTimer());
            }
            else 
            {
                _Qtesprite2.SetActive(false);
                GameOver();
            }
        }
    else if (_RandQTE== 3)
        {
            _Qtesprite3.SetActive(true);
           
            if (Input.GetKeyDown("joystick button 2"))
            {
                //condition reset perso
                Debug.Log("victoire QTE");
                StartCoroutine(QteTimer());
            }
            else
            {
                _Qtesprite3.SetActive(false);
                GameOver();
            }
        }
    else if (_RandQTE== 4) 
        {
            _Qtesprite4.SetActive(true);
            

            if (Input.GetKeyDown("joystick button 3"))
            {
                //condition reset perso
                Debug.Log("victoire QTE");
                StartCoroutine(QteTimer());
            }
            else
            {
                _Qtesprite4.SetActive(false);
                GameOver();
            }
        }

    }

    IEnumerator QteTimer()
    {
        Debug.Log("top");
        _TimerOff= false;
        yield return new WaitForSeconds(3.5f);
        _TimerOff= true;
        Debug.Log(_TimerOff);
    }

    public void GameOver()
    {
        //condition game over
        Debug.Log("Game Over");
    }
    
}
