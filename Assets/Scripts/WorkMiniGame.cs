using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class WorkMiniGame : MonoBehaviour
{
    //Serialized variables
    [SerializeField]private Gradient gradient;
    [SerializeField] private Slider workProgressBar;
    [SerializeField] private Image fillImg;
    [SerializeField] private float workIntensity;
    [SerializeField] private TMP_Text timerText;

    //Private variables
    private float maxTime;
    private float currentTime;
    private float totalProgress;

    //Public variables
    public WorkStates currentState;
	public enum WorkStates
    {
        PreStart,
		Started,
		Finished,
        ExitWork
    }

    WorkStates CurrentWorkState
    {
        get {
            return currentState;
        }
		set
        {
			currentState = value;
        }
    }
    void Start() {
        maxTime = 8f;
        totalProgress = 0;
        currentTime = maxTime;
        SetTimeUI(currentTime);
        CurrentWorkState = WorkStates.PreStart;
    }

    void Update() {
        //TODO: ADD METHOD THAT REDUCES TIMER VAL
        Timer();
    }
    public void setWorkProgressBar()
    {
        if(CurrentWorkState == WorkStates.PreStart) {
            CurrentWorkState = WorkStates.Started;
        }
        //TODO: SET WORK PROGRESS BAR UI
        float progress = workIntensity/100f;
        totalProgress += progress;
        workProgressBar.value = totalProgress;
        Debug.Log(workProgressBar.value);
        fillImg.color = gradient.Evaluate(workProgressBar.normalizedValue);
    }

    private void SetTimeUI(float time) {
        timerText.text = time.ToString("0");
    }

    public void Timer()
    {
        if (CurrentWorkState == WorkStates.ExitWork || CurrentWorkState == WorkStates.PreStart) {
            return;
        }

        if(CurrentWorkState == WorkStates.Started) {
            currentTime -= 1 * Time.deltaTime;
            SetTimeUI(currentTime);
        }

        if(currentTime <= 0)
        {
            CurrentWorkState = WorkStates.Finished;
            //GameOverState
            Debug.Log("GameOver");
            //Display Next Btn
        }
        //TODO : When the timer is less than 5 turn the timer text red
    }
}
