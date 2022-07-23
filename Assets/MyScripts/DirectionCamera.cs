using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionCamera : MonoBehaviour
{
    //private Transform cameratransform = Camera.main.gameObject.transform;
    private Vector3 cameraPosition;


    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = Camera.main.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        cameraPosition = Camera.main.gameObject.transform.position;
        var aim = cameraPosition - this.transform.position;
        var look = Quaternion.LookRotation(aim);
        this.transform.localRotation = look;
        //cameraPosition = Camera.main.gameObject.transform.position;
        //this.transform.LookAt(cameraPosition);
    }
}
