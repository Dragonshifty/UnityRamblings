using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelExit : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player"){
            StartCoroutine(exitLevel());
        }  
    }

    IEnumerator exitLevel()
    {
        yield return new WaitForSecondsRealtime(.5f);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(nextSceneIndex);
        
    }
}
