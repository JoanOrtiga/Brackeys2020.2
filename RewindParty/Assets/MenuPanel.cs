using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private Animator animator;
    private float fixedCooldown = 0.1f;
    bool show = false;
    bool hide = false;
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        animator = GetComponent<Animator>();
        Hide();
    }

    public void Show()
    {
        show = true;
        Interact();
        animator.SetBool("Show", true);
    }

    public void Hide()
    {
        hide = true;
        animator.SetBool("Show", false);
    }
    private void Interact()
    {
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    private void StopInteract()
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    private void Update()
    {
        if (hide)
        {
            if (fixedCooldown <= 0)
            {
                if (show)
                {
                    show = false;
                    hide = false;
                }
                else
                {
                    StopInteract();
                    fixedCooldown = 0.1f;
                    hide = false;
                }
            }
            else
            {
                fixedCooldown -= Time.unscaledDeltaTime;
            }
        }
    }
}
