using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Retry : MonoBehaviour
{
    private const int SceneIndex = 1;
    
    [SerializeField] private UIManager uiManager;
    
    private Button _restartButton;

    private void OnEnable()
    {
        _restartButton = GetComponent<Button>();
        _restartButton.onClick.AddListener(OnRestartButtonClick);
    }

    private void OnRestartButtonClick()
    {
        uiManager.DisableAllScreens();
        SceneManager.LoadScene(SceneIndex);
    }
}