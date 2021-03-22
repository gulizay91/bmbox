using Bmbox.Entity.Entity;
using Bmbox.Log;
using Bmbox.Model.Enums;
using Bmbox.Repository.Configuration;
using Bmbox.Repository.Interface.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bmbox.Repository.EntityFramework
{
  public class AccountMovieRepository : GenericRepository<AccountMovie, int>, IAccountMovieRepository
  {
    private BmboxContext _context;

    public AccountMovieRepository(BmboxContext dbContext) : base(dbContext)
    {
      _context = dbContext;
    }

    /*
    public List<View_GetAccountMovie_Result> AccountMovieList(int? AccountId = 0, int? MovieId = 0)
    {
      List<View_GetAccountMovie_Result> entities = new List<View_GetAccountMovie_Result>();

      try
      {

        var conn = _context.Database.GetDbConnection();
        var command = conn.CreateCommand();
        conn.Open();
        string _query = "Select * from view_getaccountmovie where 1=1 ";
        if (AccountId > 0)
          _query += ("and AccountId = " + AccountId);
        if (MovieId > 0)
          _query += ("and MovieId = " + MovieId);
        command.CommandText = _query;
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
          var record = new View_GetAccountMovie_Result
          {
            AccountMovieId = (int)reader["AccountMovieId"],
            AccountId = (int)reader["AccountId"],
            UserFullName = (string)reader["UserFullName"],
            TeamId = (int)reader["MovieId"],
            Title = (string)reader["Title"],
            IsActive = (bool)reader["IsActive"]
          };

          entities.Add(record);
        }

        //conn.Dispose();
        conn.Close();
      }
      catch (Exception ex)
      {
        entities = null;
        NLogLogger.Log(ex, "INFRASTRUCTURE_Repo", LogPriorityEnum.High);
      }


      return entities;
    }
    */

    public AccountMovie GetAccountMovieCoupling(int AccountId, int MovieId)
    {
      AccountMovie entity = new AccountMovie();

      try
      {
        entity = _context.AccountMovie
                  .SingleOrDefault(r => r.IsActive && r.Id == MovieId && r.AccountId == AccountId);

      }
      catch (Exception ex)
      {
        entity = null;
        NLogLogger.Log(ex, "INFRASTRUCTURE_Repo", LogPriorityEnum.High);
      }


      return entity;
    }

    public List<AccountMovie> AccountMovieList(int? AccountId = 0, int? MovieId = 0)
    {
      List<AccountMovie> entities = new List<AccountMovie>();

      try
      {
        entities = _context.AccountMovie
                  .Where(r => r.IsActive && (!MovieId.HasValue || r.Id == MovieId) 
                          && (!AccountId.HasValue || r.AccountId == AccountId)).ToList();

      }
      catch (Exception ex)
      {
        entities = null;
        NLogLogger.Log(ex, "INFRASTRUCTURE_Repo", LogPriorityEnum.High);
      }


      return entities;
    }
  }
}
