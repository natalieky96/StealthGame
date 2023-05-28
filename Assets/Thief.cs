using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Guard"))
        {

            // Play sound

            // Start coroutine to restart the game after sound finishes playing
            StartCoroutine(RestartGameCoroutine());
        }
    }

    private IEnumerator RestartGameCoroutine()
    {
        yield return new WaitForSeconds(4);

        // Restart the game
        RestartGame();
    }

    private void RestartGame()
    {
        // Reload the current scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

}
