using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float forwardMovementSpeed;
    [SerializeField]
    private float backMovementSpeed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float movementFuelCost;
    [SerializeField]
    private float rotationFuelCost;
    public float fuel = 100;

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * forwardMovementSpeed * Time.deltaTime);
            fuel -= movementFuelCost;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * backMovementSpeed * Time.deltaTime);
            fuel -= movementFuelCost;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            fuel -= rotationFuelCost;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
            fuel -= rotationFuelCost;
        }
    }
}
