using App.Scripts.Infrastructure.StaticData;
using UnityEngine;

namespace App.Scripts.Infrastructure.Logger
{
  public class DebugLogger
  {
    
    private static IStaticDataService _staticData;

    public DebugLogger(IStaticDataService staticData)
    {
      _staticData = staticData;
    }
    
    public static void Log(string message, LogsType logsType, DebugColorType color = DebugColorType.Silver)
    {
      if (_staticData.LoggerConfig().IsLogTypeActive(logsType)) 
        Debug.Log($"<color=#{DebugColorDictionary.Colors[color]}>{message}</color>");
    }

    public static void LogWarning(string message, LogsType logsType, DebugColorType color = DebugColorType.Yellow)
    {
      if (_staticData.LoggerConfig().IsLogTypeActive(logsType)) 
        Debug.LogWarning($"<color=#{DebugColorDictionary.Colors[color]}>{message}</color>");
    }

    public static void LogError(string message, LogsType logsType, DebugColorType color = DebugColorType.Red)
    { 
      Debug.LogError($"<color=#{DebugColorDictionary.Colors[color]}>{message}</color>");
    }
  }
}