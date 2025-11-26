using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip walkSound;
    PlayerWallStick wallStick;
    public float walkBasePitch;
    public float walkPitchRandomness;
    public float walkVolumeScale;
    public float jumpPitch;
    public int walkSoundsFrameCount;
    private int walkSoundsTimer;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        wallStick = FindAnyObjectByType<PlayerWallStick>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(wallStick.isMoving && wallStick.grounded && walkSoundsTimer == 0)
        {
            audioSource.pitch = walkBasePitch + Random.Range(-walkPitchRandomness, walkPitchRandomness);
            audioSource.PlayOneShot(walkSound, walkVolumeScale);
        }
        walkSoundsTimer--;
        if(walkSoundsTimer == 0)
        {
            walkSoundsTimer = walkSoundsFrameCount;
        }
    }
    public void PlayJumpSFX()
    {
        audioSource.pitch = jumpPitch;
        audioSource.PlayOneShot(jumpSound);
    }
}
