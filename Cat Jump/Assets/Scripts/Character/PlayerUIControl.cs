using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIControl :MonoBehaviour
{
    CharacterControl _characterControl;

    private void Awake()
    {
       _characterControl=gameObject.GetComponent<CharacterControl>();
    }
    void Start()
    {
     
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
           
            _characterControl.MovePlayerRight();
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
          
            _characterControl.MovePlayerLeft();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            _characterControl.PlayerJump();
        }
    }
}
