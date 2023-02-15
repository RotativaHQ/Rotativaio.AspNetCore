using System;
using System.Collections.Generic;
using System.Text;

namespace Rotativaio.AspNetCore
{
    public static class RotativaIoConfiguration
    {
        private static string _rotativaIoUrl;
        private static string _rotativaApiKey;
        internal static string RotativaIoUrl
        {
            get
            {
                if (string.IsNullOrEmpty(_rotativaIoUrl))
                {
#if NET45
                    _rotativaHqUrl = System.Configuration.ConfigurationManager.AppSettings["RotativaHqUrl"];
#endif
                }
                return _rotativaIoUrl;
            }
        }

        internal static string RotativaIoApiKey
        {
            get
            {
                if (string.IsNullOrEmpty(_rotativaApiKey))
                {
#if NET45
                    _rotativaHqUrl = System.Configuration.ConfigurationManager.AppSettings["RotativaHqApiKey"];
#endif
                }
                return _rotativaApiKey;
            }
        }

        public static void SetRotativaIoUrl(string newRotativaHqUrl)
        {
            _rotativaIoUrl = newRotativaHqUrl;
        }

        public static void SetRotativaIoApiKey(string newRotativaHqApiKey)
        {
            _rotativaApiKey = newRotativaHqApiKey;
        }
    }

}
