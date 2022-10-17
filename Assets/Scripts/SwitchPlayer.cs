using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayer : MonoBehaviour
{
    public GameObject[] characters; 
    public float tick, cooldown;
    
    private int characterAtual;
    private GameObject character;
    private GameObject player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        characterAtual = 0;
        character = Instantiate(characters[characterAtual], transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = player.transform.position;
        tick += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse1) && tick >= cooldown)
        {
            switchCharacter();
            Destroy(character, 0);
            character = Instantiate(characters[characterAtual], transform.position, transform.rotation);
            tick = 0;
        }
    }

    private void switchCharacter()
    {
        if (characterAtual < 2)
        {
            characterAtual += 1;
        }
        else
        {
            characterAtual = 0;
        }
    }
}
