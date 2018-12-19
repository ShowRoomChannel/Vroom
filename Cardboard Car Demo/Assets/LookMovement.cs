using UnityEngine;
using System.Collections;

public class LookMovement : MonoBehaviour
{
    // Reference to CardboardMain object
    GameObject cardboardMain;

    // Reference to Nav Mesh Agent component in CardboardMain
    NavMeshAgent navmeshAgent;
    public float Hspeed = 2.0f;
    public float Vspeed = 2.0f;
    public Vector3 axis = Vector3.up;
    // Use this for initialization
    void Start()
    {
        cardboardMain = GameObject.Find("GvrMain");
       
        // Obtain reference to Nav Mesh Agent component
        navmeshAgent = GetComponent<NavMeshAgent>();
        var horizontalSpeed = Hspeed * Input.GetAxis("Mouse X");
        var VerticalSpeed = Vspeed * Input.GetAxis("Mouse Y");
        cardboardMain.transform.Rotate(VerticalSpeed, axis.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalSpeed = Hspeed * Input.GetAxis("Mouse X");
        var VerticalSpeed = Vspeed * Input.GetAxis("Mouse Y");
        cardboardMain.transform.Rotate(VerticalSpeed, horizontalSpeed, 0);
    }
}

//using UnityEngine;
//using System.Collections;

//public class testRotate2 : MonoBehaviour
//{

//    GameObject cube;
//    public Transform center;
//    public Vector3 axis = Vector3.up;
//    public Vector3 desiredPosition;
//    public float radius = 2.0f;
//    public float radiusSpeed = 0.5f;
//    public float rotationSpeed = 80.0f;

//    void Start()
//    {
//        cube = GameObject.FindWithTag("lamborghini");
//        center = cube.transform;
//        transform.position = (transform.position - center.position).normalized * radius + center.position;
//        radius = 2.0f;
//    }

//    void Update()
//    {
//        transform.RotateAround(center.position, axis, rotationSpeed * Time.deltaTime);
//        desiredPosition = (transform.position - center.position).normalized * radius + center.position;
//        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
//    }
//}
