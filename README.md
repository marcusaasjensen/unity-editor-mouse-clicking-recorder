# editor-mouse-clicking-recorder

Unity project made by Marcus Aas Jensen.

You can share this project as long as you mention my complete name in one of the files project.
If you encounter any major bugs or issues by using this project, you can contact me via my email: aasjensenm@gmail.com

## My links
You can support me by following me on

Youtube: https://www.youtube.com/MarcusAasJensen_

Instagram: https://www.instagram.com/marcus_aasjensen

Github: https://github.com/marcusaasjensen

Itchio: https://marcus-a.itch.io

Or, you can simply share this hyperlink to my linktree:
https://linktr.ee/marcus_a

Stay curious as platypuses!

## Introduction
Hello Unity Game developers. 
So you want to create a rythm game like Osu! or Just Shapes & Beats? Do you struggle in making levels that require GameObjects to react at the very specific rythm of your music? 
Or you simply try to manually add the right timing through scripting or keyframe animations which seems to be pretty exhausting tasks.

If so, I might have a solution that would fit accordingly to your needs and even save you a lot of time in creating your rythm games.
I present you the Mouse Clicking Recorder, a Unity-based tool that allows you to record your mouse clickings and replay it according to your game mechanics.
This way, you could simply listen to your music, record your mouse, and click with your mouse at the rythm of the music.
Then, you would be able to reuse or modify the timing between your clicks and implement it with your game's code.

## Guide
Before using this project, it is recommended to use **_Unity version 2021.3.0f1_**. Of course, you can try other versions, but I haven't tested it myself.

### Setup
Download the project and open it with the Unity Hub. It is a 3D project but when you understand how to use the tool, you can implement it in any other projects too.

When opening the project, make sure to have the EditorMouseClickingRecorder scene opened in **_Assets > Scenes_**.

You will see this Hierarchy:

![](https://github.com/marcusaasjensen/editor-mouse-clicking-recorder/raw/main/Images/hierarchy.png "Hierarchy")

And you will have this project Assets tree:

![](https://github.com/marcusaasjensen/editor-mouse-clicking-recorder/raw/main/Images/project.png "Project Assets Tree")


### First Example Try
Click on the "Mouse Clicking Recorder" GameObject and see the MouseClickingRecorder component.
You can see I have already made a recording example tagged "recording_example" you can try in PlayMode.

![](https://github.com/marcusaasjensen/editor-mouse-clicking-recorder/raw/main/Images/mouseclickingrecorder_inspector.png "MouseClickingRecorder Inspector")

It is simply a list of all the times recorded between each mouse clicks.

Click on the "Recording Player" GameObject and see the RecordingPlayer component.
It is the player that will allow us to play and replay the recording in PlayMode with an audio and a visual feedback.

![](https://github.com/marcusaasjensen/editor-mouse-clicking-recorder/raw/main/Images/recordingplayer_inspector.png "RecordingPlayer Inspector")

Before playing the recording example in PlayMode, make sure to have 
the MouseClickingRecorder GameObject's component referenced, 
the tag name "recording_example" written, 
the "click" audio feedback referenced
and the "Visual Feedback" GameObject referenced in the RecordingPlayer component. 

You can twick the other settings if you want: a tooltip will appear on some settings to understand its function.

Now, enter in PlayMode!

*tum, tululum, tum, ...tum, tum!*

![](https://github.com/marcusaasjensen/editor-mouse-clicking-recorder/raw/main/Images/music.png "PlayMode Visual")

As you can see, you have a music note that appears and a *click* sound that plays exactly as my mouse clickings was recorded at the time.

If you want, you can replay the recording by right clicking on the RecordingPlayer component and select **_Play Recording (In Play Mode)_**.

Now, exit Play Mode, I will explain you how to record your own mouse clickings...

### Recording your Own Mouse Clickings
First, go to the **MouseClickingRecorder** component of the "Mouse Clicking Recorder" GameObject. You can delete the recording example with the list options (-).
Create a new empty element in the list and call its tag however you like.

![](https://github.com/marcusaasjensen/editor-mouse-clicking-recorder/raw/main/Images/new_recording.png "New Recording")

Write it in the **RecordingTag** variable too, this way, it will only affect changes to this specific recording.

![](https://github.com/marcusaasjensen/editor-mouse-clicking-recorder/raw/main/Images/start.png "Recording Settings")

Set the variable **IsRecording** to true.

![](https://github.com/marcusaasjensen/editor-mouse-clicking-recorder/raw/main/Images/waiting.png "Console Waiting Message")

You will see a green message in the Console telling you it will start to record your mouse clickings when you do your first mouse click on the above button.
Indeed, this button is the clicking zone. Then, when you are ready, start clicking at the rythm you want!

You will see the list bellow getting bigger each time you click.

![](https://github.com/marcusaasjensen/editor-mouse-clicking-recorder/raw/main/Images/recorded.png "My New Recording")

To stop the recording, simply set to false the **IsRecording** variable.

![](https://github.com/marcusaasjensen/editor-mouse-clicking-recorder/raw/main/Images/recording.png "Console Stop Message")

And then you are done!
If you want to, you can change the placements of the different recorded times in the list or simply change things manually to be more precise. 

You can also start another recording session on an **existing recording**. 
Be cautious, **the first click will be the last mouse click you have made when you have lastly recorded this list**. 
So remember this to stay in rythm!

## Play your Own Recording
Now that you have finished recording yourself, it's time to hear and see how it shows up with the "Recording Player" GameObject. 

Go to the RecordingPlayer component and write the tag of your recording. 
You can also add how much time you want to wait before it starts and you can choose how much time the visual feedback should appear.
Then enter Play Mode and you have your recording playing just like mine!

Now, you know how to use the tool I created. Very simple.

### Implementing to your own project
To implement this tool, you will need the scripts MouseClickingRecorder and MousClickingRecorderEditor. 
RecordingPlayer would be the script you would adapt according to your game's mechanics.

In the Hierarchy, you will need two empty GameObjects: one with the MouseClickingRecorder script attached and one with the RecordingPlayer script attached.
Name the GameObjects accordingly.
In the RecordingPlayer component, you will need to reference all of the different variables accordingly (see line 64).

To change what you want to happen each time a mouse click is played, you will only need to change one method in the script.

Open the RecordingPlayer script and go to the PlayRecording() Coroutine.

```cs
    IEnumerator PlayRecording(string tag)
    {
        //yield return new WaitForSeconds(timeBeforeStarting); // Optional
        List<double> recording = mouseClickingRecorder.recordingDictionary[tag];
        for (int i = 1; i < recording.Count; i++)
        {
            PlayFeedbacks(); // This is the function you would change according to your needs.
            yield return new WaitForSeconds((float) recording[i]);
        }
    }
```
Here, the PlayFeedbacks() method call is what happens at each mouse click played. So, you will only need to change this!

## Last words

Thank you for reading and taking the time to learn to use this tool. I Hope it will help you in your game development journey. 

If it helped, you can send me a message on my social medias. To support me, you can share my work and links to others.

*Making games is hard, but it doesn't have to be that hard.*

But mostly, enjoy your gamedev journey!

Marcus.


