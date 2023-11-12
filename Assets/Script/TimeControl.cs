using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour
{
    private bool inProgress;
    private DateTime TimerStart;
    private DateTime TimerEnd;
    

    [Header("Production time")]
    public int Days;
    public int Hours;
    public int Minutes;
    public int Seconds;

    [Header("UI")]
    [SerializeField] private GameObject window;
    //[SerializeField] private Text startTimeText;
    //[SerializeField] private Text endTimeText;
    [SerializeField] private GameObject timeLeftObj;
    //[SerializeField] private Text timeLeftText;
    [SerializeField] private Slider timeLeftSlider;
    [SerializeField] private GameObject youngmonster;
    [SerializeField] private GameObject monster;

    //[SerializeField] private Button skipButton;
    //[SerializeField] private Button startButton;

    #region Unity methods

    private void Start()
    {
        //startButton.onClick.AddListener(StartTimer);
        StartTimer();
    }

    #endregion

    #region UI methods

    private void InitializeWindow()
    {
        //startTimeText.text = "Start Time: \n" + TimerStart;
        //endTimeText.text = "End Time: \n" + TimerEnd;

        timeLeftObj.SetActive(true);
        StartCoroutine(DisplayTime());
        youngmonster.SetActive(true);
        monster.SetActive(false);

        //startButton.gameObject.SetActive(false);
    }

    private IEnumerator DisplayTime()
    {
        DateTime start = DateTime.Now;
        TimeSpan timeLeft = TimerEnd - start;
        double totalSecondsLeft = timeLeft.TotalSeconds;
        double totalSeconds = (TimerEnd - TimerStart).TotalSeconds;
        string text;

        while (window.activeSelf && timeLeftObj.activeSelf)
        {
            text = "";
            timeLeftSlider.value = 1 - Convert.ToSingle((TimerEnd - DateTime.Now).TotalSeconds / totalSeconds);

            if (totalSecondsLeft > 1)
            {
                if (timeLeft.Days != 0)
                {
                    text += timeLeft.Days + "d ";
                    text += timeLeft.Hours + "h";
                    yield return new WaitForSeconds(timeLeft.Minutes * 60);
                }
                else if (timeLeft.Hours != 0)
                {
                    text += timeLeft.Hours + "h ";
                    text += timeLeft.Minutes + "m";
                    yield return new WaitForSeconds(timeLeft.Seconds);
                }
                else if (timeLeft.Minutes != 0)
                {
                    TimeSpan ts = TimeSpan.FromSeconds(totalSecondsLeft);
                    text += ts.Minutes + "m ";
                    text += ts.Seconds + "s";
                }
                else
                {
                    text += Mathf.FloorToInt((float)totalSecondsLeft) + "s";
                }

                //timeLeftText.text = text;

                totalSecondsLeft -= Time.deltaTime;
                yield return null;
            }
            else
            {
                //timeLeftText.text = "Finished";
                //skipButton.gameObject.SetActive(false);
                timeLeftSlider.value = 1;
                inProgress = false;
                break;
            }
        }
        yield return null;
    }
    private void Update()
    {
        DateTime start = DateTime.Now;
        TimeSpan timeLeft = TimerEnd - start;
        double totalSecondsLeft = timeLeft.TotalSeconds;
        double totalSeconds = (TimerEnd - TimerStart).TotalSeconds;

        

        if (totalSecondsLeft <= (totalSeconds / 2))
        {
            youngmonster.SetActive(false);
            monster.SetActive(true);
        }
        else
        {
            youngmonster.SetActive(true);
            monster.SetActive(false);
        }
        
    }
    #endregion

    #region Timed event

    private void StartTimer()
    {
        TimerStart = DateTime.Now;
        TimeSpan time = new TimeSpan(Days, Hours, Minutes, Seconds);
        TimerEnd = TimerStart.Add(time);
        inProgress = true;

        StartCoroutine(Timer());

        InitializeWindow();
    }

    private IEnumerator Timer()
    {
        DateTime start = DateTime.Now;
        double secondsToFinished = (TimerEnd - start).TotalSeconds;
        yield return new WaitForSeconds(Convert.ToSingle(secondsToFinished));

        inProgress = false;
        Debug.Log("Finished");
    }
    #endregion
}


