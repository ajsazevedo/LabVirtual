using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ReactSideBar.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TerminalController : ControllerBase
  {

    private readonly ILogger<TerminalController> _logger;

    public TerminalController(ILogger<TerminalController> logger)
    {
      _logger = logger;
    }

    [HttpGet, Route("Start")]
    public void Start(string user, string password)
    {
      if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
      {

      }
      else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
      {
        ProcessStartInfo pInfo = new ProcessStartInfo();
        pInfo.FileName = @"c:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe";
        pInfo.Arguments = $@"-nolog -command cmdkey /generic:TERMSRC/Produtos028 /user:INTRANET\{user} /pass:{password}; mstsc /v:Produtos028";
        pInfo.WorkingDirectory = @"C:\users\anton";
        pInfo.WindowStyle = ProcessWindowStyle.Hidden;
        pInfo.CreateNoWindow = false;
        pInfo.UseShellExecute = true;
        Process.Start(pInfo);
      }
    }
  }
}

