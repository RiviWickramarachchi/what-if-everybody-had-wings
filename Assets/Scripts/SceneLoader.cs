using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private float sceneTransitionTime = 2f;
    [SerializeField] private float levelTransitionTime = 5f;
    [SerializeField] private Animator transition;

    //public variables
    public static event Action OnSceneChange;
    private void OnEnable() {
        SceneTrigger.OnSceneTriggered += DecideLoader;
        GameManager.OnDayEnd += LoadLevel;
        WorkMiniGame.OnSceneEnd += DecideLoader;
    }

    private void LoadScene(string sceneName) {
        //TODO: Fade To Black
        //Transition To Work Scene
        //Reverse fade
        Debug.Log("Loading" + sceneName);
        StartCoroutine(SceneTransition(sceneName));
    }

    public void LoadLevel () {
        //TODO: Load next level using Scene index
        //Make sure to add the base levels (days) close to eachother so that the transitions can be made easy
        Debug.Log("Loading Main Scene");
        StartCoroutine(LevelTransition());
    }

    private void DecideLoader(string sceneName) {
        if(GameManager.Instance.IsInMiniGame) {
            GameManager.Instance.IsInMiniGame = false;
            GameManager.Instance.CheckTodoCompletion(); //SEE IF A NEW LEVEL NEEDS TO BE LOADED
            LoadLevel();
        }
        else {
            GameManager.Instance.IsInMiniGame = true;
            OnSceneChange?.Invoke();
            LoadScene(sceneName);
        }
    }

    IEnumerator SceneTransition(string sceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(sceneTransitionTime);

        SceneManager.LoadScene(sceneName);
    }

    //changes
    IEnumerator LevelTransition()
    {
        transition.SetTrigger("Start");
        if(GameManager.Instance.todoList.Count != 0) {
            yield return new WaitForSeconds(sceneTransitionTime);
        }
        else {
            yield return new WaitForSeconds(levelTransitionTime);
        }


        SceneManager.LoadScene(1); //index for the main scene
    }
    private void LoadFinal() {
        //TODO: Load End Game Scene
    }
    private void OnDisable() {
        SceneTrigger.OnSceneTriggered -= DecideLoader;
        GameManager.OnDayEnd -= LoadLevel;
        WorkMiniGame.OnSceneEnd -= DecideLoader;
    }
}
