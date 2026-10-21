using UnityEngine;
using UnityEngine.InputSystem;

public class Ballscript : MonoBehaviour
{
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = InputSystem.actions["Horizontal"].ReadValue<float>();
        float verticalMove = InputSystem.actions["Vertical"].ReadValue<float>();
        Vector3 movement = new Vector3(horizontalMove, 0, verticalMove);
        rb.AddForce(movement);

    }
}
