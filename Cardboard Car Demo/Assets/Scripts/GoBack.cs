using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour {
    DeviceOrientation prev;
	// Use this for initialization
	void Start () {
        prev = Input.deviceOrientation;
    }
	
	// Update is called once per frame
	void Update () {
        DeviceOrientation orientation = Input.deviceOrientation;
        if((prev == DeviceOrientation.LandscapeLeft || prev == DeviceOrientation.LandscapeRight) && (orientation == DeviceOrientation.Portrait || orientation == DeviceOrientation.PortraitUpsideDown))
        {
            SceneManager.LoadScene("VehicleMenu");
        }
	}
}
