using UnityEngine;
using UnityEngine.Networking;

public class PlayerAnimationController : NetworkBehaviour
{

    private static readonly int HorizontalF = Animator.StringToHash("Horizontal_f");
    private static readonly int VerticalF = Animator.StringToHash("Vertical_f");
    private static readonly int Index = Animator.StringToHash("Index");
    private static readonly int PickUp = Animator.StringToHash("PickUp");
    private static readonly int Slap = Animator.StringToHash("Slap");
    private static readonly int Slapped = Animator.StringToHash("Slapped");
    private static readonly int HasItem = Animator.StringToHash("HasItem");

    private Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void UpdateMovement(float horizontal, float vertical)
    {
        _animator.SetFloat(HorizontalF, horizontal);
        _animator.SetFloat(VerticalF, vertical);
    }

    
}
