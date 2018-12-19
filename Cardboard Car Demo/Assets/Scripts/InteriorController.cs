using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InteriorController : MonoBehaviour
{
    public GameObject cam;
    public Material[] interiors;
    public GameObject sphere;
    public Image fade;
    private bool fading = false;
    private int index = 0;
    // Use this for initialization
    void Start()
    {
        sphere.GetComponent<Renderer>().material = interiors[index];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            cam.transform.Rotate(new Vector3(0, -1, 0));
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            cam.transform.Rotate(new Vector3(0, 1, 0));
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            cam.transform.Rotate(new Vector3(-1, 0, 0));
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            cam.transform.Rotate(new Vector3(1, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine("changeInterior");
        }
    }

    public void changeButton()
    {
        StartCoroutine("changeInterior");
    }
    public IEnumerator changeInterior()
    {
        if (!fading)
        {
            fading = true;
            while (fade.color.a < 1)
            {
                fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, fade.color.a + .1f);
                yield return null;
            }
            index++;
            if (index >= interiors.Length)
            {
                index = 0;
            }
            sphere.GetComponent<Renderer>().material = interiors[index];
            while (fade.color.a > 0)
            {
                fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, fade.color.a - .1f);
                yield return null;
            }
            fading = false;
        }
    }
}
