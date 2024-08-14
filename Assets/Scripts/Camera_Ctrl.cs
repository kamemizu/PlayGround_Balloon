using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Ctrl : MonoBehaviour
{
    [SerializeField] private GameObject balloon;
    private Camera Camera;
    private Vector3 CameraPos;
    private float followSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x - balloon.transform.position.x) * (transform.position.x - balloon.transform.position.x) > 25)
        {
            followSpeed++;
        }
        else if(followSpeed > 10)
        {
            followSpeed--;
        }
        CameraPos = Vector3.MoveTowards(CameraPos, balloon.transform.position, followSpeed * Time.deltaTime);
        transform.position = new Vector3(CameraPos.x, CameraPos.y, -10);
        Camera.orthographicSize = CameraPos.y + 5;
    }
}
