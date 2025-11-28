//using Mapster;
//using MapsterMapper;
//using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Logging.Console;
//using BackendPlatform.Service.DTOs;
//using Serilog;

//namespace BackendPlatform.API.DTOs
//{
//    public static class ObjectMapper
//    {
//        private static readonly ILoggerFactory _loggerFactory;

//        static ObjectMapper()
//        {
//            _loggerFactory = LoggerFactory.Create(builder =>
//            {
//                builder.AddFilter(level => level >= LogLevel.Information)
//                .AddConsole();
//                //.AddSerilog();

//                //builder.AddConsole();
//            });
//        }

//        //private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
//        //{
//        //    var config = new TypeAdapterConfig();
            
//        //    //var config = new MapperConfiguration(cfg =>
//        //    //{
//        //    //    cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
//        //    //    cfg.AddProfile<API2ServiceMapper>();
//        //    //});

//        //    //return config.CreateMapper();
//        //});

//        public static IMapper Mapper => Lazy.Value;
//    }

//    //public class API2ServiceMapper : Profile
//    //{
//    //    public API2ServiceMapper()
//    //    {
//    //        // 在這邊建立對應關係
//    //       // CreateMap<API_LoginRequest, Service_LoginRequest>().ForMember(dto => dto.Pwd, map => map.MapFrom(source => $"AAA_{source.Password.Substring(0, 3)}"));
//    //    }
//    //}
//}
