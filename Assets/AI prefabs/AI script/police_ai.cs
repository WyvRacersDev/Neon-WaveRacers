using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class police_ai: MonoBehaviour
{
    public CarController carController;
    public Transform[] waypoints;
    public float targetRadius = 1f;
    public float maxSpeed = 10f; // Maximum speed the car can reach
    public float accelerationRate = 2f; // Rate at which the car accelerates
    public float decelerationRate = 4f; // Rate at which the car decelerates
    public float reverseSpeed = -1f; // Speed at which the car reverses
    public float turnSpeed = 100f; // Speed at which the car turns

  
    public float currentSpeed = 0f; // Current speed of the car
    private float steeringAngle = 0f; // Steering angle of the car
    public bool reversing = false;
    public bool braking = false;

    public GameObject target;
    void Awake()
    {
        carController = GetComponent<CarController>();
        target=GameObject.Find("Player");

    }

    private void Update()
    {
        // If there are no waypoints, or the car controller is not set, exit
       
        braking = false;
        // Calculate direction to the current waypoint
        Vector3 direction = (target.transform.position - transform.position).normalized;

        // Calculate the angle between current forward direction and the desired direction
        float angle = Vector3.SignedAngle(transform.forward, direction, Vector3.up);

        // Calculate the steering angle based on the angle to the waypoint
        steeringAngle = Mathf.Clamp(angle / 180f, -1f, 1f);

        // Calculate acceleration or deceleration based on distance to the waypoint
        float distanceToWaypoint = Vector3.Distance(transform.position, target.transform.position);
        float acceleration = distanceToWaypoint > 5f ? 1f : Mathf.Clamp01(distanceToWaypoint / 5f);


        // Gradually increase or decrease speed up to the maximum speed
        if (acceleration > currentSpeed)
            currentSpeed = Mathf.Min(currentSpeed + accelerationRate * Time.deltaTime, maxSpeed);


        // Update car controller with steering and acceleration
        if (!reversing)
            carController.UpdateControls(steeringAngle, currentSpeed / maxSpeed, false);
        else
            carController.UpdateControls(steeringAngle, -1f, false);

        // Debug draw line to the current waypoint
        Debug.DrawLine(transform.position,target.transform.position, Color.red);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a wall
        if (!collision.gameObject.CompareTag("Car"))
        {
            // Reverse the car
            reversing = true;
            StartCoroutine("end");

        }
    }



    IEnumerator end()
    {
        yield return new WaitForSeconds(1);
        reversing = false;
    }

}