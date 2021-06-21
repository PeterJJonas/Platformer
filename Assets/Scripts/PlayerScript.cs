using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float _characterSpeed = 5.0f;
    [SerializeField] private float _gravity = 1.0f;
    [SerializeField] private float _playerJumpHigh = 15.0f;
    [SerializeField] private GameObject[] _playerRestartPosition;

    [SerializeField] private Text _coinText;

    private CharacterController _playerController;

    private float _yVelocity;
    private bool _doubleJump = false;
    private bool _levelRestart = false;

    [SerializeField] private int _characterScore = 0;

    void Start()
    {
        _playerController = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        if (_levelRestart)
        {
            Debug.Log("Level Restart");
            transform.position = _playerRestartPosition[0].transform.position;
            _levelRestart = false;
        }
        else
        {
            float _horizontalPlayerInput = (Input.GetAxis("Horizontal"));
            Vector3 direction = new Vector3(_horizontalPlayerInput, 0, 0);
            Vector3 velocity = direction * _characterSpeed;

            if (_playerController.isGrounded == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _yVelocity = _playerJumpHigh;
                    _doubleJump = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space) && _doubleJump == true)
                {
                    _yVelocity += _playerJumpHigh;
                    _doubleJump = false;
                }
                _yVelocity -= _gravity;
            }

            velocity.y = _yVelocity;
            _playerController.Move(velocity * Time.deltaTime);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FallCollider")
        {
            Debug.Log("fallCollided");
            _levelRestart = true;
        }
    }

    public void AddCharacterScore(int ScoreToAdd)
    {
        _characterScore += ScoreToAdd;
    }

    public int GetCharacterScore()
    {
        return _characterScore;
    }
}
