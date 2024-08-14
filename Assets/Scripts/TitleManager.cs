using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject balloon;
    [SerializeField] private GameObject ground;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = -30; i < 30; i++)
        {
            Instantiate(ground, new Vector3(i * 8.0F, 0, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(balloon.transform.position.x > 200 || balloon.transform.position.x < -200)
        {
            balloon.transform.position = new Vector2(0, 8);
            camera.transform.position = Vector2.zero;
        }
    }

    public void PushStart()
    {
        SceneManager.LoadScene("Main");
    }
}
