using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Retry : MonoBehaviour
{
    [SerializeField] private Manager manager;
    
    private Button _restartButton;
    private int _first = 1;

    private void OnEnable()
    {
        _restartButton = GetComponent<Button>();
        _restartButton.onClick.AddListener(OnRestartButtonClick);
    }

    private void OnRestartButtonClick()
    {
        manager.DisableAllScreens();
        SceneManager.LoadScene(_first);
    }
}