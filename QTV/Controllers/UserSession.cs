using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTV.Controllers
{
    public class UserSession
    {
        private static UserSession _instance;
        private static readonly object _lock = new object();

        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }

        private UserSession() { }

        public static UserSession Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new UserSession();
                        }
                    }
                }
                return _instance;
            }
        }
    }
}
