using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    [SerializeField] private Text _coinText;

    private PlayerScript _playerScript;
    private int _score;

    void Start()
    {
        _playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    void Update()
    {
        DisplayCharacterScore();
    }

    private void DisplayCharacterScore()
    {
        _score = _playerScript.GetCharacterScore();
        _coinText.text = _score.ToString();
    }
}