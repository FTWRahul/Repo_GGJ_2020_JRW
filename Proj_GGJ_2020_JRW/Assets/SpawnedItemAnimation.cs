using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnedItemAnimation : MonoBehaviour
{
    public float jumpForce;
    public Vector3 randomPoint;
    public Ease ease;
    public void Start()
    {
        transform.DOJump(randomPoint, jumpForce,1, Random.Range(2, 4)).SetEase(ease);
    }
}
