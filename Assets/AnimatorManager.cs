using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator PlayerAnimator;

    public void SetAttackAnimation()
    {
        PlayerAnimator.Play("Attack");
    }
    public void SetWalkAnimation()
    {
        PlayerAnimator.Play("Walk");
    }
    public void SetInteractAnimation()
    {
        PlayerAnimator.Play("Interact");
    }
    public void SetPickUpAnimation()
    {
        PlayerAnimator.Play("Pick Up");
    }
    public void SetDanceAnimation()
    {
        PlayerAnimator.Play("Dance");
    }
    public void SetDefeatAnimation()
    {
        PlayerAnimator.Play("Defeat");
    }
    public void SetDashBackAnimation()
    {
        PlayerAnimator.Play("DashBack");
    }
}