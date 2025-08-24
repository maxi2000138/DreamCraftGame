using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace App.Scripts.Infrastructure.Logger._Configs
{
  [CreateAssetMenu(fileName = nameof(LoggerConfig), menuName = "Configs/" + nameof(LoggerConfig))]
  public sealed class LoggerConfig : SerializedScriptableObject
  {
    [DictionaryDrawerSettings(IsReadOnly = true, DisplayMode = DictionaryDisplayOptions.OneLine)]
    [SerializeField]
    private Dictionary<LogsType, bool> _logsActive = new Dictionary<LogsType, bool>();

    private void OnEnable()
    {
      foreach (LogsType logType in Enum.GetValues(typeof(LogsType))) 
        _logsActive.TryAdd(logType, true);
    }

    public bool IsLogTypeActive(LogsType logsType)
    {
      return _logsActive.TryGetValue(logsType, out bool isActive) && isActive;
    }
  }
}