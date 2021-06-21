using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private PlayerScript _playerScript;
    // Start is called before the first frame update
    void Start()
    {
        _playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        if (_playerScript == null)
        {
            Debug.LogError("No Player Object's Found!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _playerScript.AddCharacterScore(10);
            Destroy(gameObject);
        }
    }

}
