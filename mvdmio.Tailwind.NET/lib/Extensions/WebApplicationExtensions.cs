using System.Diagnostics;

namespace mvdmio.Tailwind.NET.lib.Extensions;

/// <summary>
/// Helper class for Tailwind methods
/// </summary>
public static class Tailwind
{
   public static void RunTailwindBuild()
   {
      var cmd = CommandLine;
      cmd.StandardInput.WriteLine("msbuild -target:BuildTailwind");
   }

   public static void RunTailwindWatch()
   {
      var cmd = CommandLine;
      cmd.StandardInput.WriteLine("msbuild -target:WatchTailwind");
   }

   private static Process CommandLine
   {
      get
      {
         var process = new Process();
         process.StartInfo.FileName = "cmd.exe";
         process.StartInfo.RedirectStandardInput = true;
         process.StartInfo.RedirectStandardOutput = true;
         process.StartInfo.UseShellExecute = false;
         process.Start();

         return process;
      }
   }
}