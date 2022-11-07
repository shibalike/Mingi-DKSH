using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject Target; //카메라 대상
    public int Smoothvalue = 2; //부드러운 정도

    // Use this for initialization
    public Coroutine my_co;

    void Start()
    {
     
    }

    void Update()
    {
        Vector3 Targetpos = new Vector3(Target.transform.position.x, Target.transform.position.y, -100);
        transform.position = Vector3.Lerp(transform.position, Targetpos, Time.deltaTime * Smoothvalue);
        //Lerp 함수는 카메라 위치 알려줌
    }
}