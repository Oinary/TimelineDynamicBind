using System.Collections.Generic;
using UnityEngine.Playables;

internal interface IDynamicBindReference<T>
{
    Dictionary<string, T> BindTable { get; }
    void Bind(IEnumerable<IDynamicBind<T>> RefData, PlayableDirector director);
}