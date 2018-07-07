using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 0f;
    
    public float fuel;
    public float maxFuel = 100f;

    private float maxForwardSpeed = 1.5f;
    private float maxBackwardSpeed = 0.75f;
    
    private float rotationSpeed = 40f;

    private float forwardAcceleration = 0.5f;
    private float backwardAcceleration = 0.375f;
    private float automaticAcceleration = 0.25f;

    private float forwardMovementFuelCost = 0.125f;
    private float backwardMovementFuelCost = 0.0635f;
    private float RotationFuelCost = 0.03175f;

    private float MovementSpeed { get { return movementSpeed; } set { if (movementSpeed >= 0) { if (value <= maxForwardSpeed) { movementSpeed = value; } } else if (movementSpeed <= 0) { if (value >= -maxBackwardSpeed) { movementSpeed = value; } } } } // checks if the value you want to set movementspeed to is not bigger than the maxspeed

    private void Start()
    {
        fuel = maxFuel;
    }

    private void Update()
    {
            if (Input.GetKey(KeyCode.D) && fuel >= 0)
            {
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
                fuel -= RotationFuelCost;
            }
            if (Input.GetKey(KeyCode.A) && fuel >= 0)
            {
                transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
                fuel -= RotationFuelCost;
            }
            if (Input.GetKey(KeyCode.W) && fuel >= 0)
            {
                MovementSpeed += forwardAcceleration * Time.deltaTime;
                fuel -= forwardMovementFuelCost;
            }
            else if (Input.GetKey(KeyCode.S) && fuel >= 0)
            {
                MovementSpeed -= backwardAcceleration * Time.deltaTime;
                fuel -= backwardMovementFuelCost;
            }
            else if (movementSpeed > 0)
            {
                MovementSpeed -= automaticAcceleration * Time.deltaTime;
            }
            else if (movementSpeed < 0)
            {
                MovementSpeed += automaticAcceleration * Time.deltaTime;

            }
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }
}
