using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public Image barraDeVida;
    public int maxLives = 3;
    public int lives;

    public float dmgDelay = 0.5f;

    void Start()
    {
        lives = maxLives;
    }

    void Update()
    {
        barraDeVida.fillAmount = maxLives;
    }

    public void Damage()
    {
        if (lives > 0)
        {
            lives = lives - 1;
        }


        if (lives == 0)
        {
            GameStateManager statemanager = FindFirstObjectByType<GameStateManager>();
            statemanager.ChangeState(GameStateManager.GameState.OVER);

            return;
        }

        PlayerController hCtr = gameObject.GetComponent<PlayerController>();
        hCtr.cAnimator.SetBool("Hurt", true);
        StartCoroutine(HurtDelay());

        UIHealth health = FindFirstObjectByType<UIHealth>();
        health.UpdateHealth(lives);

        hCtr.cRenderer.DOColor(Color.red, 0.5f).SetEase(Ease.InOutSine);
        hCtr.cRenderer.DOColor(Color.white, 0.5f).SetDelay(0.5f).SetEase(Ease.InOutSine);

    }

    IEnumerator HurtDelay()
    {
        yield return new WaitForSeconds(dmgDelay);

        PlayerController hCtr = gameObject.GetComponent<PlayerController>();
        hCtr.cAnimator.SetBool("Hurt", false);
    }

    public void Regenerate()
    {
        lives = lives + 1;

    }
}

