using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Script you will use as a component in your GameObject MouseClickingRecorder.
/// All of your recordings will be saved in the recording list.
/// Through your own script (SEE EXAMPLE SCRIPT "RecordingPlayer"), you can play the recordings you have created and use it according to your needs.
/// </summary>

[DisallowMultipleComponent]
public class MouseClickingRecorder : MonoBehaviour
{
    [System.Serializable]
    public class Recording
    {
        public string tag;
        public List<double> timeBetweenClicks;
    }

    [Tooltip("Check this box to start recording your mouse clicks. Uncheck if you want to stop recording.")]
    public bool isRecordingMouseClicks = false;

    [Tooltip("Tag of the recording you want to affect when recording your mouse clicks.")]
    public string recordingTag;
    
    [Tooltip("List of all of your timing recordings. Make sure to create an empty or an existing recording and use its tag to record your timings with your mouse.")]
    public List<Recording> recordingList;

    public Dictionary<string, List<double>> recordingDictionary;
    public static MouseClickingRecorder Instance { get; private set; }

    private double _timeOffset;
    private double _timer;

    private bool _hasStartedRecording;
    private bool _isFirstClick;

    private void Awake() 
    {
        #region Singleton
        if (Instance == null) Instance = this;
        #endregion

        recordingDictionary = new Dictionary<string, List<double>>();
        foreach(var recording in recordingList)
            recordingDictionary.Add(recording.tag, recording.timeBetweenClicks);
    }

    /// <summary>
    /// Function that returns the recording with the according tag if it exists. Otherwise, the function will return null.
    /// </summary>
    /// <param name="tag">Tag of the recording you want to check.</param>
    /// <returns></returns>
    public Recording ContainsRecordingWithTag(string tag)
    {
        foreach(var recording in recordingList)
            if(recording.tag == tag) 
                return recording;
        
        return null;
    }

    public void StartRecording()
    {
        Recording recording = ContainsRecordingWithTag(recordingTag);
        if (recording is null)
        {
            Debug.LogWarning("the recording with tag \"" + recordingTag + "\" does not exist.");
            isRecordingMouseClicks = false;
            return;
        }

        if (_hasStartedRecording) return;
        _hasStartedRecording = true;
        _isFirstClick = true;

        Debug.Log($"<color=#AAFF00>Waiting for the first click before starting recording...</color>");
    }

    public void StopRecording()
    {
        if (_hasStartedRecording)
        {
            ContainsRecordingWithTag(recordingTag).timeBetweenClicks.Add(0);
            Debug.Log($"<color=#AAFF00>Recording stopped.</color>"); 
        }
        _hasStartedRecording = false;
        _timer = 0;
    }
#if UNITY_EDITOR
    public void AddKeyFrame()
    {
        var keyFrameList = ContainsRecordingWithTag(recordingTag).timeBetweenClicks;

        if (_isFirstClick)
        {
            _timeOffset = EditorApplication.timeSinceStartup;
            _isFirstClick = false;

            if (keyFrameList.Count > 0 && keyFrameList[^1] == 0)
                keyFrameList.RemoveAt(keyFrameList.Count-1);

            if (keyFrameList.Count == 0)
                keyFrameList.Add(0);

            Debug.Log($"<color=#AAFF00>Recording...</color>");
            return;
        }

        var previousTime = _timer;
        _timer = EditorApplication.timeSinceStartup - _timeOffset;
        var timeBetweenTwoClicks = _timer - previousTime;

        keyFrameList.Add(timeBetweenTwoClicks);
    }
#endif
}