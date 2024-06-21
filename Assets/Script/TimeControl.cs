using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class TimeControl : MonoBehaviour
    {
        private bool     inProgress;
        private DateTime TimerStart;
        private DateTime TimerEnd;

        [Header("Production time")] 
        
        [SerializeField] private int Days;
        [SerializeField] private int Hours;
        [SerializeField] private int Minutes;
        [SerializeField] private int Seconds;

        [Header("UI")] 
        
        [SerializeField] private GameObject window;
        [SerializeField] private GameObject timeLeftObj;
        [SerializeField] private Slider     timeLeftSlider;
        [SerializeField] private GameObject youngMonster;
        [SerializeField] private GameObject monster;

        #region Unity methods

        private void Start()
        {
            StartTimer();
        }

        #endregion

        #region UI methods

        private void InitializeWindow()
        {
            timeLeftObj.SetActive(true);
            StartCoroutine(DisplayTime());
            youngMonster.SetActive(true);
            monster.SetActive(false);
        }

        private IEnumerator DisplayTime()
        {
            var start            = DateTime.Now;
            var timeLeft         = TimerEnd - start;
            var totalSecondsLeft = timeLeft.TotalSeconds;
            var totalSeconds     = (TimerEnd - TimerStart).TotalSeconds;

            while (window.activeSelf && timeLeftObj.activeSelf)
            {
                timeLeftSlider.value = 1 - Convert.ToSingle((TimerEnd - DateTime.Now).TotalSeconds / totalSeconds);

                if (totalSecondsLeft > 1)
                {
                    if (timeLeft.Days != 0)
                    {
                        yield return new WaitForSeconds(timeLeft.Minutes * 60);
                    }
                    else if (timeLeft.Hours != 0)
                    {
                        yield return new WaitForSeconds(timeLeft.Seconds);
                    }

                    totalSecondsLeft -= Time.deltaTime;
                    yield return null;
                }
                else
                {
                    timeLeftSlider.value = 1;
                    inProgress           = false;
                    break;
                }
            }

            yield return null;
        }

        private void Update()
        {
            var start            = DateTime.Now;
            var timeLeft         = TimerEnd - start;
            var totalSecondsLeft = timeLeft.TotalSeconds;
            var totalSeconds     = (TimerEnd - TimerStart).TotalSeconds;

            if (totalSecondsLeft <= (totalSeconds / 2))
            {
                youngMonster.SetActive(false);
                monster.SetActive(true);
            }
            else
            {
                youngMonster.SetActive(true);
                monster.SetActive(false);
            }
        }

        #endregion

        #region Timed event

        private void StartTimer()
        {
            TimerStart = DateTime.Now;
            var time = new TimeSpan(Days, Hours, Minutes, Seconds);
            TimerEnd   = TimerStart.Add(time);
            inProgress = true;

            StartCoroutine(Timer());

            InitializeWindow();
        }

        private IEnumerator Timer()
        {
            var start             = DateTime.Now;
            var secondsToFinished = (TimerEnd - start).TotalSeconds;
            yield return new WaitForSeconds(Convert.ToSingle(secondsToFinished));

            inProgress = false;
            Debug.Log("Finished");
        }

        #endregion
    }
}