using UnityEngine;
using Zenject;

public class MainManuController : MonoBehaviour
{
    private const string PlayMode = "PlayMode";

    // main
    [Header("Main")]
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private GameObject _backButton;

    // settings
    [Header("Settings")]
    [SerializeField] private Setting _settings;

    [SerializeField] private GameObject _videoPanel;
    [SerializeField] private GameObject _soundPanel;
    [SerializeField] private GameObject _languagePanel;
    [SerializeField] private GameObject _controlPanel;


    private GameObject _currentOpened;
    private IStorage _storage;

    [Inject]
    private void Constract(IStorage storage)
    {
        _storage = storage;
    }

    private void Start()
    {
        Debug.developerConsoleVisible = true;
        _currentOpened = _mainMenu;

        ClearSettings();

        _settingsMenu.SetActive(false);
        _backButton.SetActive(false);
    }

    private void Update()
    {
    }

    public void Continue()
    {
        _currentOpened = _settingsMenu;
        LoadingManager.Instance.LoadScene(PlayMode);
    }

    public void Settings()
    {
        Video();
        _backButton.SetActive(true);
        _currentOpened.SetActive(false);
        _settingsMenu.SetActive(true);
        _currentOpened = _settingsMenu;
    }

    public void Back()
    {
        _currentOpened.SetActive(false);
        _mainMenu.SetActive(true);
        _currentOpened = _mainMenu;
        _backButton.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Video()
    {
        ClearSettings();
        _videoPanel.SetActive(true);
    }

    public void Sound()
    {
        ClearSettings();
        _soundPanel.SetActive(true);
    }

    public void Language()
    {
        ClearSettings();
        _languagePanel.SetActive(true);
    }

    public void Control()
    {
        ClearSettings();
        _controlPanel.SetActive(true);
    }

    private void ClearSettings()
    {
        _videoPanel.SetActive(false);
        _soundPanel.SetActive(false);
        _languagePanel.SetActive(false);
        _controlPanel.SetActive(false);
    }


}

public class TestSaver
{
    public string Name { get; set; }
    public string Description { get; set; }
}
