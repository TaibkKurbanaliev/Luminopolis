using UnityEngine;

public class PlayModeController : MonoBehaviour
{
    public void MainMenuClick()
    {
        LoadingManager.Instance.LoadScene("MainMenu");
    }
}
