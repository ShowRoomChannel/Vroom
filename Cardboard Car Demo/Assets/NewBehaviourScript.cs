using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{

    // Reference to CardboardMain object
    GameObject cardboardMain;

    // Reference to Nav Mesh Agent component in CardboardMain
    NavMeshAgent navmeshAgent;

    // Reference to skeleton object
    public GameObject skeleton;

    // Navigation agent is likely to stop when it gets very close to its destination, 
    // rather than exactly at the destination. We need to check if agent's current 
    // position is within a close margin of the destination. If so, we can assume it is
    // at the destination. The margin is set below.
    float margin = 1.0f;

    // Approximately 3 o'clock position in (x,z)-plane
    Vector3 frontDest1 = new Vector3(10, 2, 0);

    // Approximately 12 o'clock position in (x,z)-plane
    Vector3 frontDest2 = new Vector3(0, 2, 10);

    // Approximately 9 o'clock position in (x,z)-plane
    Vector3 frontDest3 = new Vector3(-10, 2, 0);

    // Navigation starting point; approximately 6 o'clock position in (x,z)-plane
    Vector3 frontDest4 = new Vector3(0, 2, -10);

    // This flag indicates rotation of travel.
    // If true, travel is in counter-clockwise direction; otherwise, 
    // it is clockwise
    bool ccw = true;
    public float Hspeed = 2.0f;
    public float Vspeed = 2.0f;
    // Camera travels along 4 distinct paths:
    // path 1: between frontDest4 (starting point) and frontDest1
    // path 2: between frontDest1 and frontDest2
    // path 3: between frontDest2 and frontDest3
    // path 4: between frontDest3 and frontDest4
    int path = 1; // Initial path

    void Start()
    {
        // Obtain reference to CardboardMain object
        cardboardMain = GameObject.Find("GvrMain");

        // Obtain reference to Nav Mesh Agent component
        navmeshAgent = GetComponent<NavMeshAgent>();

        // Obtain reference to skeleton object
        //skeleton = GameObject.Find("skeleton");
        skeleton = GameObject.Find("lamborghini");

        // Set initial destination point for travel
        navmeshAgent.destination = frontDest1;
    }

    void Update()
    {
        // Depending on whether direction of travel is counter clockwise or clockwise
        // check proximity to current destination and if we're within the margin set
        // next destination point.
        var horizontalSpeed = Hspeed * Input.GetAxis("Mouse X");
        var VerticalSpeed = Vspeed * Input.GetAxis("Mouse Y");
        cardboardMain.transform.Rotate(VerticalSpeed, horizontalSpeed, 0);
        navmeshAgent.transform.Rotate(VerticalSpeed, horizontalSpeed, 0);

        if (ccw)
        {// Current rotation is counter clockwise 			
            switch (path)
            {
                case 1: // Currently we're traveling from frontDest4 to frontDest1
                    if ((navmeshAgent.transform.position - frontDest1).magnitude <= margin)
                    {
                        navmeshAgent.destination = frontDest2;
                        path = 2;
                    }
                    break;
                case 2: // Currently we're traveling from frontDest1 to frontDest2
                    if ((navmeshAgent.transform.position - frontDest2).magnitude <= margin)
                    {
                        navmeshAgent.destination = frontDest3;
                        path = 3;
                    }
                    break;

                case 3: // Currently we're traveling from frontDest2 to frontDest3
                    if ((navmeshAgent.transform.position - frontDest3).magnitude <= margin)
                    {
                        navmeshAgent.destination = frontDest4;
                        path = 4;
                    }
                    break;
                case 4: // Currently we're traveling from frontDest3 to frontDest4
                    if ((navmeshAgent.transform.position - frontDest4).magnitude <= margin)
                    {
                        navmeshAgent.destination = frontDest1;
                        path = 1;
                    }
                    break;

                default:
                    break;
            }
        }
        else
        {// Current rotation is clockwise
            switch (path)
            {
                case 1: // Currently we're traveling from frontDest1 to frontDest4
                    if ((navmeshAgent.transform.position - frontDest4).magnitude <= margin)
                    {
                        navmeshAgent.destination = frontDest3;
                        path = 4;
                    }
                    break;
                case 2: // Currently we're traveling from frontDest2 to frontDest1
                    if ((navmeshAgent.transform.position - frontDest1).magnitude <= margin)
                    {
                        navmeshAgent.destination = frontDest4;
                        path = 1;
                    }
                    break;

                case 3: // Currently we're traveling from frontDest3 to frontDest2
                    if ((navmeshAgent.transform.position - frontDest2).magnitude <= margin)
                    {
                        navmeshAgent.destination = frontDest1;
                        path = 2;
                    }
                    break;
                case 4: // Currently we're traveling from frontDest4 to frontDest3
                    if ((navmeshAgent.transform.position - frontDest3).magnitude <= margin)
                    {
                        navmeshAgent.destination = frontDest2;
                        path = 3;
                    }
                    break;

                default:
                    break;
            }
        }
        // Maintain current transform of Cardboard Main object towards skeleton
        //cardboardMain.transform.LookAt(skeleton.transform);
    }

    public void ToggleRotation()
    {
        // Change rotation from clockwise to counter-clockwise and vice versa.

        if (ccw)
        { // Current rotation is counter-clockwise
            ccw = false; // change direction
            switch (path)
            { // Depending on current path, change destination point
                case 1:
                    navmeshAgent.destination = frontDest4;
                    break;
                case 2:
                    navmeshAgent.destination = frontDest1;
                    break;
                case 3:
                    navmeshAgent.destination = frontDest2;
                    break;
                case 4:
                    navmeshAgent.destination = frontDest3;
                    break;
                default:
                    break;
            }
        }
        else
        { // Current rotation is clockwise
            ccw = true; // change direction
            switch (path)
            { // Depending on current path, change destination point
                case 1:
                    navmeshAgent.destination = frontDest1;
                    break;
                case 2:
                    navmeshAgent.destination = frontDest2;
                    break;
                case 3:
                    navmeshAgent.destination = frontDest3;
                    break;
                case 4:
                    navmeshAgent.destination = frontDest4;
                    break;
                default:
                    break;
            }
        }
    }
}