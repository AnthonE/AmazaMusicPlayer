using UnityEngine;

public class AmazaMusicPlayer : MonoBehaviour
{
    public AudioSource MusicSource;
    public MusicDetails[] MusicArray;
    public KeyCode ForwardTrackKey;
    public KeyCode BackwardTrackKey;
    private int CurrentTrackNumber = 0;
    private MusicDetails CurrentTrack;

    void Update()
    {
        if (Input.GetKeyUp(ForwardTrackKey))
        {
            CurrentTrackNumber++;
            ModifyTrackNumber(1);
        }
        else if (Input.GetKeyUp(BackwardTrackKey))
        {
            CurrentTrackNumber--;
            ModifyTrackNumber(-1);
        }
        if (!MusicSource.isPlaying)
        {
            CurrentTrackNumber++;
            ModifyTrackNumber(1);
        }
    }
    
    void ModifyTrackNumber(int Amount)
    {
        if (Amount > 0)
        {
            if (CurrentTrackNumber >= MusicArray.Length)
                CurrentTrackNumber = 0;
        }
        else
        {
            if (CurrentTrackNumber < 0)
                CurrentTrackNumber = MusicArray.Length - 1;
        }
        UpdateTrack();
    }
    
    void UpdateTrack()
    {
        CurrentTrack = MusicArray[CurrentTrackNumber];
        MusicSource.clip = CurrentTrack.Music;
        MusicSource.Play();
        UpdateUi();
    }
    
    void UpdateUi()
    {
        Debug.Log("Now Playing: "+ CurrentTrack.Artist + " " + CurrentTrack.Link +" "+CurrentTrack.License);
    }
}

[System.Serializable]
public struct MusicDetails
{
    public AudioClip Music;
    public string Artist;
    public string Link;
    public string License;
}

