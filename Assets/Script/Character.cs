using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Animator mAnimator;
    [SerializeField] private Material mMaterial;
   

    void Start()
    {
        mAnimator = GetComponent<Animator>();
        mMaterial.color = Color.red;
    }

    // Update is called once per frame
    public void ActionWalking()
    {
        mAnimator.SetTrigger("TrWalk");
        mMaterial.color = Color.green;
    }
}
