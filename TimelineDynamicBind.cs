using UnityEngine;
using System.Collections.Generic;
using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Cinemachine;
using UnityEngine.Timeline;
using System.Linq;
using UnityEngine.Playables;

/// <summary>
/// 
/// </summary>
internal class TimelineDynamicBind : SerializedMonoBehaviour, IDynamicBindReference<CinemachineVirtualCamera>
{
    [SerializeField]
    private Dictionary<string, CinemachineVirtualCamera> _BindTable;
    public Dictionary<string, CinemachineVirtualCamera> BindTable { get { return _BindTable; } }

    public void Bind(IEnumerable<IDynamicBind<CinemachineVirtualCamera>> RefData, PlayableDirector director)
    {
        foreach (var item in RefData)
        {
            TrackAsset track = item.Timeline.GetOutputTracks().FirstOrDefault(x => x.name == item.TrackName);
            Debug.Log(track);
            TimelineClip clip = track.GetClips().FirstOrDefault(x => x.displayName == item.ClipName);
            Debug.Log(clip);
            var VcamClip = clip.asset as CinemachineShot;
            director.SetReferenceValue(VcamClip.VirtualCamera.exposedName, _BindTable[item.ListKey]);
        }
    }

    [Serializable]
    internal class VcamDynamicBind : IDynamicBind<CinemachineVirtualCamera>
    {
        [SerializeField]
        private string _TrackName;
        public string TrackName { get { return _TrackName; } }
        [SerializeField]
        private string _ClipName;
        public string ClipName { get { return _ClipName; } }
        [SerializeField]
        private string _ListKey;
        public string ListKey
        {
            get { return _ListKey; }
        }
        [SerializeField]
        private TimelineAsset _Timeline;
        public TimelineAsset Timeline { get { return _Timeline; } }
    }
}

