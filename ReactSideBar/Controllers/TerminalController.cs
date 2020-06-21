using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;

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
        EditConfigFile(user, password);
        RunProcess(@"remmina", $@"-c LabConnection.remmina", Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "remmina"),
          ProcessWindowStyle.Hidden, true, false);
      }
      else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
      {
        RunProcess(@"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe", $@"-nolog -command cmdkey /generic:TERMSRC/Produtos028 /user:INTRANET\{user} /pass:{password}; mstsc /v:Produtos028",
          @"C:\",
          ProcessWindowStyle.Hidden, false, true);
      }
    }

    private void CreateConfigFile()
    {
      RunProcess(@"remmina", $@"-n LabConnection.remmina", Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "remmina"),
        ProcessWindowStyle.Hidden, true, false);
    }

    private void EditConfigFile(string user, string password)
    {
      if (!System.IO.File.Exists("LabConnection.remmina"))
        CreateConfigFile();
        RunProcess(@"remmina", $@"remmina --update-profile /LabConnection.remmina --set -option username={user} --set -option password={password}",
        Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "remmina"),
        ProcessWindowStyle.Hidden, true, false);
    }

    private void RunProcess(string fileName, string arguments, string workingDirectory, ProcessWindowStyle style, bool windowed, bool shell)
    {
      ProcessStartInfo pInfo = new ProcessStartInfo();

      pInfo.FileName = fileName;
      pInfo.Arguments = arguments;
      pInfo.WorkingDirectory = workingDirectory;
      pInfo.WindowStyle = style;
      pInfo.CreateNoWindow = windowed;
      pInfo.UseShellExecute = shell;

      using (var proc = new Process { StartInfo = pInfo })
      {
        proc.Start();
      }
    }
  }
}

