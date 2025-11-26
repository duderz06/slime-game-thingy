using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip walkSound;
    public float walkBasePitch = 1f;
    public float walkPitchRandomness = 1f;
    public float walkVolumeScale = 1f;
    public float jumpPitch = 1f;

    public float timeBetweenWalks = 0.2f;

    private void Start() {audioSource = GetComponent<AudioSource>();}

    public void PlayJumpSFX()
    {
        Debug.Log("Jump");
        audioSource.pitch = jumpPitch;
        audioSource.PlayOneShot(jumpSound);
    }
    
    public void PlayWalkSFX()
    {
        Debug.Log("Walk");
        audioSource.pitch = walkBasePitch + Random.Range(-walkPitchRandomness, walkPitchRandomness);
        audioSource.PlayOneShot(walkSound, walkVolumeScale);
    }
}
