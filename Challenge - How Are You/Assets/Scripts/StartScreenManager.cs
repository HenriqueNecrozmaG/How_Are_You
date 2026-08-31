using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartScreenManager : MonoBehaviour
{
    [SerializeField] private Canvas canvasConfigurations;

    void Start()
    {
        canvasConfigurations.enabled = false;
    }

    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button buttonStart = root.Q<Button>("Btn_Start");
        Button buttonConfigurations = root.Q<Button>("Btn_Configurations");
        Button buttonQuit = root.Q<Button>("Btn_Quit");

        buttonStart.clicked += () => Btn_Start();
        buttonConfigurations.clicked += () => Btn_Configurations();
        buttonQuit.clicked += () => Btn_Quit();
    }

    public void Btn_Start()
    {
        SceneManager.LoadScene("GameScreen");
    }

    public void Btn_Configurations()
    {
        canvasConfigurations.enabled = true;
    }

    public void Btn_Quit()
    {
        Application.Quit();
    }

    public void CloseConfigurations()
    {
        canvasConfigurations.enabled = false;
    }
}
