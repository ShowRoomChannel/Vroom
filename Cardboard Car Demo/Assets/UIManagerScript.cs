using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour
{
    public Animator contentPanel;
    public Animator gearImage;
    public Button[] options;
    public GameObject cam;
    public LayerMask mask;

    public void ToggleMenu()
    {
        bool isHidden = contentPanel.GetBool("isHidden");
        contentPanel.SetBool("isHidden", !isHidden);
        gearImage.SetBool("isHidden", !isHidden);
    }

    public void pressed()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 10000.0f, mask))
        {
            foreach(Button button in options)
            {
                if (hit.transform.gameObject.Equals(button.gameObject))
                {
                    button.onClick.Invoke();
                }
            }
        }
    }

    public void goToViewMenu()
    {
        SceneManager.LoadScene("ViewMenu");
    }

    public void goToExterior()
    {
        SceneManager.LoadScene("exterior");
    }

    public void goToInterior()
    {
        SceneManager.LoadScene("Interior");
    }
}
