using System;
using TMPro;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class Timer 
{
    private float _elapsedSeconds;
    private TMP_Text _timeText;

    public Timer(TMP_Text timeText)
    {
        _timeText = timeText;
    }

    public async void StartTimer()
    {
        _elapsedSeconds += Time.deltaTime;

        var time = TimeSpan.FromSeconds(_elapsedSeconds);

        string second = time.Seconds.ToString();
        string fractions = time.Milliseconds.ToString();
        int fractionCharLength = fractions.Length;
        fractions = (fractionCharLength > 0) ? fractions.Remove(fractionCharLength - 1) : "00";

        _timeText.text = second + "." + fractions;

        await Task.Yield();
    }

    public void UpdateScore(int score) => _elapsedSeconds += score;

    public void ResetTimer() => _elapsedSeconds = 0;
}