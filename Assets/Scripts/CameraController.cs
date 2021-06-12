using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotSpeed = 30;

    // Update is called once per frame
    void Update()
    {
		transform.Rotate(Vector3.up, -Input.GetAxisRaw("Rotate") * rotSpeed * Time.deltaTime);

    }
}
