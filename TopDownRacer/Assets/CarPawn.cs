using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPawn : MonoBehaviour
{
    [SerializeField] public Vector3 velocity = new Vector3();
    [SerializeField] float forwardSpeed = 0.02f;
    [SerializeField] [Range(0, 1)] float brakingSpeed = 0.1f;
    [SerializeField] [Range(0, 1)] float friction = 0.001f;
    [SerializeField] float handlingRating = 200f;

    void Accelerate(float accelerationAmount)
    {
        float direction;
        float xAcceleration;
        float zAcceleration;

        direction = transform.rotation.eulerAngles.y;
        zAcceleration = accelerationAmount *
            Mathf.Cos(direction * Mathf.Deg2Rad);
        xAcceleration = accelerationAmount *
            Mathf.Sin(direction * Mathf.Deg2Rad);

        velocity += new Vector3(xAcceleration, 0, zAcceleration);
    }

    void Turn(float rotationAmount)
    {
        float carMag = 0f;
        float carAngle = 0f;

        // Calculates the magnitude of the car’s velocity.
        carMag = Mathf.Sqrt(Mathf.Pow(velocity.x, 2) + Mathf.Pow(velocity.z, 2));

        // Using a Cartesian->Polar conversion to find angle.
        carAngle = Mathf.Atan2(velocity.x, velocity.z);

        // Gradually adjusting angle based on its handling and delta time.
        carAngle += rotationAmount * Time.deltaTime;

        // Wraps the angle
        while(carAngle < -Mathf.PI)
        {
            carAngle += Mathf.PI * 2;
        }
        while(carAngle > Mathf.PI)
        {
            carAngle -= Mathf.PI * 2;
        }

        // Creates the new vector based on the changed angle by converting from Polar->Cartesian.
        float newX = carMag * Mathf.Sin(carAngle);
        float newZ = carMag * Mathf.Cos(carAngle);

        velocity = new Vector3(newX, 0, newZ);
    }

    void Start() // Start is called before the first frame update
    {
    }

    void Update() // Update is called once per frame
    {
        if (Input.GetKey(KeyCode.W))
            Accelerate(forwardSpeed);
        if (Input.GetKey(KeyCode.S))
            velocity *= (1-brakingSpeed);
        if (Input.GetKey(KeyCode.A))
            Turn(-handlingRating);
        if (Input.GetKey(KeyCode.D))
            Turn(handlingRating);
        velocity *= (1- friction);
        transform.position += velocity * Time.deltaTime;
        if (velocity.x != 0 && velocity.z != 0)
        {
            float direction = (float)Mathf.Atan2(velocity.x, velocity.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, direction, 0);
        }
    }
}
