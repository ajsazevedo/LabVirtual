using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace ReactSideBar.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class StartTerminalServiceController : ControllerBase
  {

    private readonly ILogger<StartTerminalServiceController> _logger;

    public StartTerminalServiceController(ILogger<StartTerminalServiceController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public void Get()
    {
      ProcessStartInfo pInfo = new ProcessStartInfo();
      pInfo.FileName = "cmdkey";
      pInfo.ArgumentList.Add("generic:'server01'");
      pInfo.ArgumentList.Add("user:'test'");
      pInfo.ArgumentList.Add("pass:'PW'");

      Process.Start(pInfo);

      ProcessStartInfo pInfo2 = new ProcessStartInfo();
      pInfo2.FileName = "mstsc";
      pInfo2.ArgumentList.Add("v:'server01'");

      Process.Start(pInfo2);
    }
  }
}

