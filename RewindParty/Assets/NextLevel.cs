using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<Animator>();
        anim.SetBool("Change", false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("Change", true);
            StartCoroutine(LoadScene());
        }
    }
    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(0.35f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
