using Bmbox.Log;
using Bmbox.Model.Enums;
using Bmbox.Repository.Interface.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Bmbox.Service.Implementation
{
  public class BaseService
  {
    protected readonly IUnitOfWork _sourceEntity;

    public BaseService(IUnitOfWork sourceEntity)
    {
      _sourceEntity = sourceEntity;
    }

    #region  ExceptionHandling
    protected T ExecuteWithExceptionHandledOperation<T>(Func<T> func, string errorText = null) where T : class
    {
      try
      {
        var result = func.Invoke();

        return result;
      }
      catch (Exception ex)
      {
        ex.Data.Add("errorText-business", errorText);
        NLogLogger.Log(ex, "APPLICATION", LogPriorityEnum.High);

        if (string.IsNullOrEmpty(errorText))
          errorText = "Yapılan işlem sırasında hata oluştu.";
        System.Type type = typeof(T);//aynı tip oluşturulur.
        ConstructorInfo magicConstructor = type.GetConstructor(System.Type.EmptyTypes);//constructure oluşturulur.
        object magicClassObject = magicConstructor.Invoke(new object[] { });//sınıf oluşturulur.
        MethodInfo methodInfo = type.GetMethod("Fail");//oluşturulan sınıfın Fail metodu bulunur.
        methodInfo.Invoke(magicClassObject, new object[] { 500, ex.HelpLink == "CustomException" ? ex.Message : errorText });//ilgili metodu gelen parametrelerle çağırırız.

        return magicClassObject as T;
      }
    }

    protected void ExecuteWithExceptionHandledOperation(Action action)
    {
      try
      {
        action.Invoke();
      }
      catch (Exception ex)
      {
        NLogLogger.Log(ex, "BUSINESS", LogPriorityEnum.High);
      }
    }

    /// <summary>
    /// Generic Pagination -> İç içe sahip modeller için kullanılacaktır
    /// </summary>
    /// <typeparam name="TResponse"> Sonucun Döneceği İtem Tipi </typeparam>
    /// <typeparam name="TEntity"> Sayfalama Yapılacak İtem Tipi</typeparam>
    /// <param name="paginatedList">Sayfalama sonucu dönülecek Liste</param>
    /// <param name="willBePaginationList"> Sayfalama yapılacak Liste </param>
    /// <param name="countEntityInOnePage"> Sayfalama kaç item üzerinden yapılacak</param>
    /// <returns></returns>
    protected List<TResponse> CreatePagination<TResponse, TEntity>(List<TResponse> paginatedList, List<TEntity> willBePaginationList, int countEntityInOnePage) where TResponse : class where TEntity : class
    {
      int paginationCount = (int)(willBePaginationList.Count / countEntityInOnePage) + 1;
      List<TResponse> response = new List<TResponse>();
      List<TEntity> mapperList = new List<TEntity>();
      for (int i = 0; i < paginationCount; i++)
      {
        for (int j = 1; j < willBePaginationList.Skip(i * countEntityInOnePage).Count() + 1; j++)
        {
          TEntity dbEntity = (TEntity)Activator.CreateInstance(typeof(TEntity), new object[] { willBePaginationList[j - 1 + (i * countEntityInOnePage)] });
          mapperList.Add(dbEntity);
          if (j % countEntityInOnePage == 0 || (willBePaginationList.Count() == mapperList.Count() && i * countEntityInOnePage < willBePaginationList.Count() && willBePaginationList.Count() < (i + 1) * countEntityInOnePage))
          {
            TResponse pagedEntity = (TResponse)Activator.CreateInstance(typeof(TResponse), new object[] { mapperList, i + 1 });
            response.Add(pagedEntity);
            mapperList = new List<TEntity>();
            break;
          }
        }
      }
      return response;
    }
    #endregion
  }
}