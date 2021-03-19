using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Business.Core;
using TMS.Common.Core;

namespace TMS.Service.Controllers
{
    public class BaseController : Controller
    {
        private IActionManager manager;
        private ILogger logger;

        public BaseController(IActionManager manager, ILogger logger)
        {
            this.manager = manager;
            this.logger = logger;
        }

        public IActionManager ActionManager
        {
            get
            {
                return manager;
            }
        }

        public ILogger Logger
        {
            get
            {
                return logger;
            }
        }

        public void LogException(Exception ex)
        {
            string errorMessage = LoggerHelper.GetExceptionDetails(ex);
            logger.LogError(LoggingEvents.SERVICE_ERROR, ex, errorMessage);
        }
    }
}
