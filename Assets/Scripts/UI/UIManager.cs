using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Knife _knife;
    [SerializeField] private Canvas _retryScreen;
    [SerializeField] private Canvas _finisScreen;
    
    public void DisableAllScreens()
    {
        _finisScreen.gameObject.SetActive(false);
        _retryScreen.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _knife.HitedTarget += ShowFinishScreen;
        _knife.Crashed += ShowRetryScreen;
    }

    private void OnDisable()
    {
        _knife.HitedTarget -= ShowFinishScreen;
        _knife.Crashed -= ShowRetryScreen;
    }

    private void ShowFinishScreen()
    {
        _finisScreen.gameObject.SetActive(true);
    }

    private void ShowRetryScreen()
    {
        _retryScreen.gameObject.SetActive(true);
    }
}