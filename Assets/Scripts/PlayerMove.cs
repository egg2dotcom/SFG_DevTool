using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody _rb = null;
    [SerializeField] float _maxSpeed = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 inputRaw = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        inputRaw.Normalize(); // clamp all inputs to 1 so that way you can't diagonal strafe

        _rb.MovePosition(_rb.position + new Vector3(inputRaw.x * _maxSpeed, 0, inputRaw.z * _maxSpeed));
    }
}
