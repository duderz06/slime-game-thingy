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

    public float timeBetweenWalks = 0.2f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        wallStick = FindAnyObjectByType<PlayerWallStick>();
    }
    // Update is called once per frame
    /*void FixedUpdate()
    {
        Debug.Log("work");
        if(wallStick.isMoving && wallStick.grounded && walkSoundsTimer == 0)
        {
            Debug.Log("play");
            audioSource.pitch = walkBasePitch + Random.Range(-walkPitchRandomness, walkPitchRandomness);
            audioSource.PlayOneShot(walkSound, walkVolumeScale);
        }
        walkSoundsTimer--;
        if(walkSoundsTimer == 0)
        {
            walkSoundsTimer = walkSoundsFrameCount;
        }
    }*/
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
