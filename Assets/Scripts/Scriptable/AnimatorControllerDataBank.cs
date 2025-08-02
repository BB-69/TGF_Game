using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DataBank/AnimatorControllerDataBank")]
public class AnimatorControllerDataBank : ScriptableObject
{
    public List<ControllerEntry> controllerList = new List<ControllerEntry>();

    private Dictionary<string, RuntimeAnimatorController> _controllerDict;

    public RuntimeAnimatorController GetController(string conName)
    {
        if (_controllerDict == null)
        {
            _controllerDict = new Dictionary<string, RuntimeAnimatorController>();
            foreach (var entry in controllerList)
                if (!_controllerDict.ContainsKey(entry.name))
                    _controllerDict.Add(entry.name, entry.controller);
        }

        Debug.Log(_controllerDict);

        return _controllerDict.ContainsKey(conName) ? _controllerDict[conName] : null;
    }
}

[Serializable]
public struct ControllerEntry
{
    public string name;
    public RuntimeAnimatorController controller;
}
