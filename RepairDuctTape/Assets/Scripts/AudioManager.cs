using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] tapeSfx;
    public AudioClip[] maleSfx;
    public AudioClip completeSfx;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void TapePlay()
    {
        PlaySfx(tapeSfx[Random.Range(0, tapeSfx.Length-1)]);
    }

    public void CompletePlay()
    {
        PlaySfx(completeSfx);
    }

    public void MalePlay()
    {
        PlaySfx(tapeSfx[Random.Range(0, maleSfx.Length-1)]);
    }

    public void StopSfx()
    {
        _audioSource.Stop();
    }
    
    public void PlaySfx(AudioClip clip)
    {
        StopSfx();
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}
