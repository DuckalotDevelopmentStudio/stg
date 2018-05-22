using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float ForwardMovementSpeed;
    public float BackMovementSpeed;
    public float RotationSpeed;
    public float MovementFuelCost;
    public float RotationFuelCost;
    public float Fuel = 100;
     
    void FixedUpdate() {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * ForwardMovementSpeed * Time.deltaTime);      // Moves the player forward
            Fuel -= MovementFuelCost;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(- Vector3.forward * BackMovementSpeed * Time.deltaTime);    // Moves the player back
            Fuel -= MovementFuelCost;
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);               // Rotates the player to the left
            Fuel -= RotationFuelCost;
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -RotationSpeed * Time.deltaTime);              // Rotates the player to the right
            Fuel -= RotationFuelCost;
        }
    }
}
