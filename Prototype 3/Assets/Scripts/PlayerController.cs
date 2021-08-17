using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    private float _jumpForce = 700;
    private float _gravityModifier = 1.5f;
    private bool _isOnGround = true;
    [HideInInspector]
    public bool gameOver;

    private Animator _playerAnim;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource _audioPlayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= _gravityModifier;

        _playerAnim = GetComponent<Animator>();
        _audioPlayer = GetComponent<AudioSource>();
        transform.position = Vector3.Lerp(transform.position, new Vector3(0, 0.05f, 0), -1f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isOnGround = false;
            _playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            _audioPlayer.PlayOneShot(jumpSound, 1.0f);
        }else if(Input.GetKeyDown(KeyCode.Space) && !gameOver && transform.position.y < 5)
        {
            rb.AddForce(Vector3.up * _jumpForce * 0.8f, ForceMode.Impulse);
            _isOnGround = false;
            _playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            _audioPlayer.PlayOneShot(jumpSound, 1.0f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
            dirtParticle.Play();
        }else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over Man!");
            _playerAnim.SetBool("Death_b", true);
            _playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            _audioPlayer.PlayOneShot(crashSound, 1.0f);
        }
        
    }
}
