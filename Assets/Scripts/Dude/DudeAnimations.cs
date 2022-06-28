using UnityEngine;
public class DudeAnimations : MonoBehaviour
{
    [SerializeField] private DudeWithKnife dudeWithKnife;
    [SerializeField] private Animator _animator;
    
    private const string Throw = "Throw";
    
    private void OnEnable()
    {
        dudeWithKnife.Geted += KnifeTrow;
    }

    private void OnDisable()
    {
        dudeWithKnife.Geted -= KnifeTrow;
    }

    private void KnifeTrow()
    {
        _animator.SetTrigger(Throw);
    }
}
