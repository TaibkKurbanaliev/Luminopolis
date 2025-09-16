using System.Runtime.Serialization;
using UnityEngine;

public class ResolutionSurogate : ISerializationSurrogate
{
    public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
    {
        var res = (Resolution) obj;
        info.AddValue("width", res.width);
        info.AddValue("height", res.height);

    }

    public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
    {
        return null;
    }
}
