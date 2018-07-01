using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 0f;
    [SerializeField]
    public float fuel;

    [SerializeField]
    private float maxFuel = 100f;

    private float maxForwardSpeed = 1.5f;
    private float maxBackwardSpeed = 0.75f;
    
    private float RotationSpeed = 40f;

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
            if (Input.GetKey(KeyCode.D) && fuel >= 0)                                       // checks for keyinput and of there is any fuel left
            {
                transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);               // Rotates the player to the left
                fuel -= RotationFuelCost;                                                   // decreases the fuel
            }
            if (Input.GetKey(KeyCode.A) && fuel >= 0)
            {
                transform.Rotate(Vector3.up, -RotationSpeed * Time.deltaTime);              // Rotates the player to the right
                fuel -= RotationFuelCost;                                                   // decreases the fuel
            }
            if (Input.GetKey(KeyCode.W) && fuel >= 0)
            {
                MovementSpeed += forwardAcceleration * Time.deltaTime;                      // Moves the player forward
                fuel -= forwardMovementFuelCost;                                                   // decreases the fuel
            }
            else if (Input.GetKey(KeyCode.S) && fuel >= 0)
            {
                MovementSpeed -= backwardAcceleration * Time.deltaTime;                     // Moves the player backward
                fuel -= backwardMovementFuelCost;                                                   // decreases the fuel
            }
            else if (movementSpeed > 0)                                                     // Ckecks if the player is moven forward when no key is pressed to move it
            {
                MovementSpeed -= automaticAcceleration * Time.deltaTime;                    // brakes the player when it is moving forward
            }
            else if (movementSpeed < 0)
            {
                MovementSpeed += automaticAcceleration * Time.deltaTime;                    // brakes the player when it is moving backward

            }
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);          // actually moves the player based on the movementspeed witch is defined in the last four if statements
    }
}
