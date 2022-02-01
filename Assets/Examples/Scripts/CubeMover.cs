using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    [SerializeField, Range(0.5f, 5.0f)]
    private float _speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Horizontal");

        if (input != 0)
        {
            transform.position += Vector3.right * _speed * Time.deltaTime * input;
        }
    }
}
