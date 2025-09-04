using UnityEngine;

public class MainManuController : MonoBehaviour
{
    private const string PlayMode = "PlayMode";

    public void Continue()
    {
        LoadingManager.Instance.LoadScene(PlayMode);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
