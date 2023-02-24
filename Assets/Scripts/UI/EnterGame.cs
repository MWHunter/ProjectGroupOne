
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterGame : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button m_compsci;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        m_compsci.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}