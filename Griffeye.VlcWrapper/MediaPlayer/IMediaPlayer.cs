﻿using System;
using System.Collections.Generic;
using Griffeye.VideoPlayerContract.Enums;
using Griffeye.VlcWrapper.Models;
using LibVLCSharp.Shared;

namespace Griffeye.VlcWrapper.MediaPlayer
{
    public interface IMediaPlayer
    {
        event EventHandler<EventArgs> EndReached;
        event EventHandler<long> TimeChanged;
        event EventHandler<MediaPlayerLengthChangedEventArgs> LengthChanged;
        event EventHandler<VideoInfo> VideoInfoChanged;
        event EventHandler<EventArgs> Playing;
        event EventHandler<EventArgs> Paused;
        event EventHandler<MediaPlayerVolumeChangedEventArgs> VolumeChanged;
        event EventHandler<EventArgs> Unmuted;
        event EventHandler<EventArgs> Muted;

        public void ConnectLocalFileStream(string pipeName);
        void Play();
        void Pause();
        void LoadMedia(StreamType type, string file, float startPosition, float stopPosition);
        void Seek(float position);
        void SetPlaybackSpeed(float speed);
        void SetVolume(int volume);
        void SetMute(bool mute);
        void StepForward();
        void StepBack();
        void DisconnectLocalFileStream();
        bool CreateSnapshot(int numberOfVideoOutput, int width, int height, string filePath);
        List<(int, string)> GetAudioTracks();
        List<(int, string)> GetVideoTracks();
        void SetAudioTrack(int trackId);
        void SetVideoTrack(int trackId);
    }
}