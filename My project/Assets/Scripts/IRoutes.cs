using System.Collections.Generic;
using UnityEngine;

public interface IRoutes
{
    public Dictionary<string, List<Transform>> GetRoutes();
}
