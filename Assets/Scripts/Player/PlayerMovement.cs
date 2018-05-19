using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float MovementSpeed;                                                         
    public float RotationSpeed;

    void FixedUpdate() {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * MovementSpeed * Time.deltaTime);      // Moves the player forward
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(- Vector3.forward * MovementSpeed * Time.deltaTime);    // Moves the player back
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);               // Rotates the player to the left
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, -RotationSpeed * Time.deltaTime);              // Rotates the player to the right
        }
    }
}
