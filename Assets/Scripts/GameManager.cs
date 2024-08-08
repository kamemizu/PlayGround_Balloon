using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //�J�n�G�t�F�N�g
    [SerializeField] private GameObject yoi;
    [SerializeField] private GameObject start;
    //�X�g�b�p�[
    [SerializeField] private GameObject stoper;
    private float startTimer = 3;
    // Start is called before the first frame update
    void Start()
    {
        yoi.SetActive(false);
        start.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        startTimer -= Time.deltaTime;
        if(startTimer < 2)
        {
            yoi.SetActive(true);
        }
        if (startTimer < 0.5)
        {
            yoi.SetActive(false);
            start.SetActive(true);
            stoper.SetActive(false);
        }
        if (startTimer < 0)
        {
            start.SetActive(false);
        }
    }
}
