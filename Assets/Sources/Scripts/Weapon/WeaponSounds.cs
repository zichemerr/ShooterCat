using UnityEngine;

public class WeaponSounds : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _shoot;

    public void PlayShoot()
    {
        _audioSource.PlayOneShot(_shoot);
    }
}
