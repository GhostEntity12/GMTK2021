using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public int interactionLayer;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        interactionLayer = 1 << gameObject.layer & 1 << 8;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
