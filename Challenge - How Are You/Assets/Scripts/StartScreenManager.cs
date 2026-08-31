using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartScreenManager : MonoBehaviour
{
    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button buttonStart = root.Q<Button>("Btn_Start");
        Button buttonOptions = root.Q<Button>("Btn_Options");
        Button buttonQuit = root.Q<Button>("Btn_Quit");

        buttonStart.clicked += () => Btn_Start();
        buttonOptions.clicked += () => Btn_Options();
        buttonQuit.clicked += () => Btn_Quit();
    }

    public void Btn_Start()
    {
        SceneManager.LoadScene("GameScreen");
    }

    public void Btn_Options()
    {
        print("Options");
    }

    public void Btn_Quit()
    {
        Application.Quit();
    }
}
