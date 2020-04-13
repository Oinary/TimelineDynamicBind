using UnityEngine.Timeline;
internal interface IDynamicBind<T>
{
    string TrackName { get; }
    string ClipName { get; }
    string ListKey { get; }
    TimelineAsset Timeline { get; }
}
