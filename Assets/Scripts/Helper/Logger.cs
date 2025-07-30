using System;
using UnityEngine;

public class Logger
{
    private readonly string prefix;

    public Logger(string componentName, MonoBehaviour owner = null)
    {
        CharacterComponent character = owner != null ? owner.GetComponent<CharacterComponent>() : null;
        string entityInfo = (character != null)
            ? $":Entity#{character.index}({owner.gameObject.name})"
            : $"";

        prefix = $"[{componentName}{entityInfo}]";
    }

    public void Log(string msg) { Debug.Log($"{prefix} {msg}"); }
    public void Warn(string msg) { Debug.LogWarning($"{prefix} ⚠️ {msg}"); }
    public void Error(string msg) { Debug.LogError($"{prefix} ❌ {msg}"); }
}
