using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenLaptopUIScript : MonoBehaviour
{

    public void OnMouseDown()
    {
        SceneManager.LoadScene("LaptopUI", LoadSceneMode.Single);
    }
}
