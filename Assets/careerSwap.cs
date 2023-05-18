using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class careerSwap : MonoBehaviour
{

    public void OnMouseDown()
    {
        GameManager.Instance.ResetGameData();
        SceneManager.LoadScene(0);
    }
}
