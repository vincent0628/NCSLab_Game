using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinHandler : MonoBehaviour
{
	public Animator animator;
    public AnimatorOverrideController SwitchDefaultAnim;
    public AnimatorOverrideController SwitchBAnim;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
		{
			animator.runtimeAnimatorController = SwitchDefaultAnim as RuntimeAnimatorController;
		}

        if (Input.GetKeyDown(KeyCode.W))
		{
            animator.runtimeAnimatorController = SwitchBAnim as RuntimeAnimatorController;
		}
    }
}
