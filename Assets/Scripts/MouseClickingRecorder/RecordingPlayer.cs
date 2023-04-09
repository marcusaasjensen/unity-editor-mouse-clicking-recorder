using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Example script for playing the mouse clicking recordings.
/// You Can change it according to your needs.
/// In this script, you can access to your recordings by referencing the MouseClickingRecorder GameObject (mouseClickingRecorder) here
/// and access the recording dictionary as
///
/// List<double> recording = mouseClickingRecorder.recordingDictionary;
///
/// SEE "PlayRecording" COROUTINE
/// You can "do something" at each mouse click played by looping through the numbers of "recording" in a Coroutine (here named "PlayRecording") and by typecasting the time to wait from double to float
/// just as
///
/// for(int i = 1; i < recording.Count; i++) {
///      DoSomething();
///      yield return new WaitForSeconds((float) recording[i]);
/// }
/// </summary>

[DisallowMultipleComponent]
public class RecordingPlayer : MonoBehaviour
{
    [Header("Player Settings")]

    [Space]
    public MouseClickingRecorder mouseClickingRecorder;

    [Tooltip("Tag of the recording you want to play.")]
    public string recordingTagToPlay;

    [Tooltip("Time to wait before the recording is played.")]
    [Min(0)]
    public float timeBeforeStarting; // Optional
    
    [Header("Feedback Settings")]
    [Space]
    public AudioClip audioFeedback; // Optional

    [Space]
    public GameObject visualFeedback; // Optional
    [Tooltip("Time defining for how long the visual feedback will appear.")]
    [Min(0)]
    public float appearingTime = .2f; // Optional

    private void Start()
    {
        mouseClickingRecorder = MouseClickingRecorder.Instance;
        visualFeedback.SetActive(false);

        if (mouseClickingRecorder.ContainsRecordingWithTag(recordingTagToPlay) == null) 
        {
            Debug.LogWarning("The recording \"" + recordingTagToPlay + "\" does not exist.");    
            return; 
        }

        StartCoroutine(PlayRecording(recordingTagToPlay));
    }

    [ContextMenu("Play Recording (In Play Mode)")]
    /// <summary>
    /// Function you can use during Play Mode to replay the recording by right clicking on the script and choosing "Play Recording (In Play Mode)". 
    /// </summary>
    private void PlayCurrentRecording()
    {
        if (mouseClickingRecorder.ContainsRecordingWithTag(recordingTagToPlay) == null)
        {
            Debug.LogWarning("The recording \"" + recordingTagToPlay + "\" does not exist.");
            return;
        }
        StartCoroutine(PlayRecording(recordingTagToPlay));
    }

    /// <summary>
    /// Function you will need to play the recording you want.
    /// </summary>
    /// <param name="tag">Tag of the recording you want to play.</param>
    private IEnumerator PlayRecording(string tag)
    {
        yield return new WaitForSeconds(timeBeforeStarting); // Optional
        var recording = mouseClickingRecorder.recordingDictionary[tag];
        for (var i = 1; i < recording.Count; i++)
        {
            PlayFeedbacks(); // This is the function you would change according to your needs.
            yield return new WaitForSeconds((float) recording[i]);
        }
    }
    /// <summary>
    /// Function defining what will happen at each mouse click played.
    /// </summary>
    private void PlayFeedbacks()
    {
        if (visualFeedback != null) StartCoroutine(Appear());
        if (audioFeedback != null) AudioSource.PlayClipAtPoint(audioFeedback, transform.position);
    }

    private IEnumerator Appear()
    {
        visualFeedback.SetActive(true);
        yield return new WaitForSeconds(appearingTime);
        visualFeedback.SetActive(false);
    }
}