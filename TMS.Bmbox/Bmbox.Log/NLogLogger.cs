using Bmbox.Model.Enums;
using System;

namespace Bmbox.Log
{
  public class NLogLogger
  {
    public static bool Log(Exception ex, string message = "", LogPriorityEnum priority = LogPriorityEnum.High)
    {
      try
      {
        NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        switch (priority)
        {
          case LogPriorityEnum.RedAlert:
            logger.Fatal(ex, message);
            break;
          case LogPriorityEnum.Low:
            logger.Info(ex, message);
            break;
          case LogPriorityEnum.High:

            logger.Error(ex, message);
            break;
          case LogPriorityEnum.Normal:
            logger.Warn(ex, message);
            break;
          default:
            logger.Error(ex, message);
            break;
        }
        return true;
      }
      catch (Exception e)
      {
        return false;
      }

    }
  }
}
