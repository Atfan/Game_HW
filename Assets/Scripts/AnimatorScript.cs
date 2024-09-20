using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    
    public Animator animatorPlayer;
   // Start is called before he first frame update
    void Start()
    {
        animatorPlayer = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
