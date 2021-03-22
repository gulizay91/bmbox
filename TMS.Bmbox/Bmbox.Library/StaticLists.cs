using Bmbox.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bmbox.Library
{
  public static class StaticLists
  {
    public class StringListModel
    {
      public string Value { get; set; }

      public string Text { get; set; }
    }

    public class StaticListModel
    {
      public int Id { get; set; }

      public string Name { get; set; }
    }

    //#region ProcessTypes
    //public class ProcessTypeList
    //{
    //  private static List<StringListModel> _instanceProcessTypeList = null;
    //  private static object _lockThis = new object();

    //  #region singletonInstance
    //  public static List<StringListModel> GetInstanceProcessTypes
    //  {
    //    get
    //    {
    //      lock (_lockThis)
    //      {
    //        if (_instanceProcessTypeList == null)
    //        {
    //          // TODO: enum'a eklendiginde, listeye de eklenir
    //          _instanceProcessTypeList = new List<StringListModel>
    //          {
    //            new StringListModel { Text = EnumUtils.GetEnumDescription(UserFeeProcessTypeEnum.Monthly), Value = UserFeeProcessTypeEnum.Monthly.ToString() },
    //            new StringListModel { Text = EnumUtils.GetEnumDescription(UserFeeProcessTypeEnum.Tournament), Value = UserFeeProcessTypeEnum.Tournament.ToString() },
    //            new StringListModel { Text = EnumUtils.GetEnumDescription(UserFeeProcessTypeEnum.ClubProduct), Value = UserFeeProcessTypeEnum.ClubProduct.ToString() }
    //          };
    //        }

    //        return _instanceProcessTypeList;
    //      }
    //    }
    //  }
    //  #endregion
    //}
    //#endregion

  }
}
