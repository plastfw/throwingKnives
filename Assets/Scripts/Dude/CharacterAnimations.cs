using UnityEngine;
public class CharacterAnimations : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Animator _animator;
    
    private const string Throw = "Throw";
    
    private void OnEnable()
    {
        _character.Geted += KnifeTrow;
    }

    private void OnDisable()
    {
        _character.Geted -= KnifeTrow;
    }

    private void KnifeTrow()
    {
        _animator.SetTrigger(Throw);
    }
}
