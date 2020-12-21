using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 5;
    private CharacterController _controller;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        var delta = (x: Input.GetAxis("Horizontal") * Speed, z: Input.GetAxis("Vertical") * Speed);
        var movement = new Vector3(delta.x * Time.deltaTime, -9.8f, delta.z * Time.deltaTime);
        movement = Vector3.ClampMagnitude(movement, Speed);
        _controller.Move(transform.TransformDirection(movement));
    }
}
