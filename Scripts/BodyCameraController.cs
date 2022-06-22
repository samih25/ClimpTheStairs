using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCameraController : MonoBehaviour
{
    [SerializeField] Transform _bodyTransform;



    private void Update()
    {
        transform.position = new Vector3(transform.position.x, _bodyTransform.position.y+2f, transform.position.z);
    }


}
