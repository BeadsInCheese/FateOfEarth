using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    // Define some variables and parameters for the movement
    float speed = 5f; // The speed of the character in units per second
    float direction = 0f; // The direction of the character in radians
    float strideLength = 1f; // The length of each step in units
    float footHeight = 0.5f; // The maximum height of the foot during a step in units
    float footOffset = 0.2f; // The horizontal offset of the foot from the body center in units
    float cycleTime = 1f; // The duration of one walk cycle in seconds
    float cyclePhase = 0f; // The current phase of the walk cycle in radians
    Rigidbody body;



    // Define some references to the IK components and bones
    Transform leftLegIK; // The IK component for the left leg
    Transform rightLegIK; // The IK component for the right leg
    Transform bodyIK; // The IK component for the body
    public Transform leftFootTarget; // The target transform for the left foot position
    public Transform rightFootTarget; // The target transform for the right foot position
    Transform leftKneeHint; // The hint transform for the left knee position
    Transform rightKneeHint; // The hint transform for the right knee position
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    float time=0;
    void Update()
    {
        //test
        //transform.position += new Vector3(Mathf.Cos(direction), 0f, Mathf.Sin(direction)) * speed * Time.deltaTime;
        // Update the phase of the walk cycle according to its speed and stride length
        time += Time.deltaTime;
        body.velocity = new Vector3(Mathf.Sin(time), 0,Mathf.Cos(time));
        cyclePhase += (speed / strideLength) * Time.deltaTime*0.2f * Mathf.PI * 2f;
        cyclePhase %= Mathf.PI * 2f;
        direction = Mathf.Atan2(body.velocity.y, body.velocity.x);
        
        // Calculate the vertical and horizontal positions of each foot using sine and cosine functions with some easing and offsetting 
        float leftFootVertical = Mathf.Sin(cyclePhase) * footHeight;
        float rightFootVertical = Mathf.Sin(cyclePhase + Mathf.PI) * footHeight;
        float leftFootHorizontal = -Mathf.Cos(cyclePhase) * strideLength / 2f + footOffset;
        float rightFootHorizontal = -Mathf.Cos(cyclePhase + Mathf.PI) * strideLength / 2f - footOffset;

        // Set the target positions for each foot using raycasts or colliders to detect the ground level 
        Vector3 forwardVector = new Vector3(Mathf.Cos(direction), 0f, Mathf.Sin(direction));
        Vector3 leftVector = new Vector3(-Mathf.Sin(direction), 0f, Mathf.Cos(direction));
        Vector3 rightVector = -leftVector;

        RaycastHit hit;

        if (Physics.Raycast(transform.position + forwardVector * leftFootHorizontal + Vector3.up * 10f, Vector3.down, out hit))
        {
            leftFootTarget.position = (leftFootTarget.position + hit.point + Vector3.up * leftFootVertical)/2;
        }

        if (Physics.Raycast(transform.position + forwardVector * rightFootHorizontal + Vector3.up * 10f, Vector3.down, out hit))
        {
            rightFootTarget.position =(rightFootTarget.position + hit.point + Vector3.up * rightFootVertical)/ 2;
        }
    }
}
