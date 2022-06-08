using Microsoft.AspNetCore.Http;

namespace Clase_Pasaje_De_Datos.Helpers
{
    public class SessionHelper : ISessionHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;

        public string UltimoMesCalculado
        {
            get
            {
                return _session.GetString(Keys.UltimoMesCalculado);
            }
            set
            {
                _session.SetString(Keys.UltimoMesCalculado, value);
            }
        }

        public SessionHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
        }

        class Keys
        {
            public const string UltimoMesCalculado = "UltimoMesCalculado";
        }
    }

    public interface ISessionHelper
    {
        string UltimoMesCalculado { get; set; }
    }
}
