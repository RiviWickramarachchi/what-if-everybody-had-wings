using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private float sceneTransitionTime = 2f;
    [SerializeField] private float levelTransitionTime = 5f;
    [SerializeField] private Animator transition;
    private void OnEnable() {
        SceneTrigger.OnSceneTriggered += LoadScene;
        GameManager.OnDayEnd += LoadLevel;
    }

    private void LoadScene(string sceneName) {
        //TODO: Fade To Black
        //Transition To Work Scene
        //Reverse fade
        Debug.Log("Loading" + sceneName);
        StartCoroutine(SceneTransition(sceneName));
    }

    private void LoadLevel (int levelIndex) {
        //TODO: Load next level using Scene index
        //Make sure to add the base levels (days) close to eachother so that the transitions can be made easy
    }

    IEnumerator SceneTransition(string sceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(sceneTransitionTime);

        SceneManager.LoadScene(sceneName);
    }

    IEnumerator LevelTransition(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(levelTransitionTime);

        SceneManager.LoadScene(levelIndex);
    }
    private void LoadFinal() {
        //TODO: Load End Game Scene
    }
    private void OnDisable() {
        SceneTrigger.OnSceneTriggered -= LoadScene;
        GameManager.OnDayEnd -= LoadLevel;
    }
}
