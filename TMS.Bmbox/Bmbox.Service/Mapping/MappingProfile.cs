using AutoMapper;
using Bmbox.Entity.Entity;
using Bmbox.Model.ViewModels.Account;

namespace Bmbox.Service.Mapping
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      //ValidateInlineMaps = false;
      AllowNullDestinationValues = true;

      CreateMap<Account, AccountViewModel>();
      CreateMap<AccountViewModel, Account>();
      /*
      CreateMap<AccountType, AccountTypeViewModel>();
      CreateMap<AccountTypeViewModel, AccountType>();
      
      CreateMap<AccountMovie, AccountMovieViewModel>();
      CreateMap<AccountMovieViewModel, AccountMovie>();

      CreateMap<AccountTvSeries, AccountTvSeriesViewModel>();
      CreateMap<AccountTvSeriesViewModel, AccountTvSeries>();

      CreateMap<AccountBook, AccountBookViewModel>();
      CreateMap<AccountBookViewModel, AccountBook>();
      */
    }
  }
}
