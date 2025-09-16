using UnityEngine;
using Zenject;

public class MainManuController : MonoBehaviour
{
    private const string PlayMode = "PlayMode";

    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private GameObject _backButton;

    private GameObject _currentOpened;
    private IStorage _storage;

    [Inject]
    private void Constract(IStorage storage)
    {
        _storage = storage;
    }

    private void Start()
    {
        _currentOpened = _mainMenu;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var test = new TestSaver() { Name = "Kek", Description = "Pavlisoshvili" };
            _storage.Save(test);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _storage.Load<TestSaver>(data =>
            {
                Debug.Log(data.Name);
                Debug.Log(data.Description);
            });
        }
    }

    public void Continue()
    {
        _currentOpened = _settingsMenu;
        LoadingManager.Instance.LoadScene(PlayMode);
    }

    public void Settings()
    {
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
}

public class TestSaver
{
    public string Name { get; set; }
    public string Description { get; set; }
}
