using System;
using System.Diagnostics;

namespace mvdmio.Tailwind.NET.lib;

/// <summary>
/// Helper class for Tailwind methods
/// </summary>
public static class Tailwind
{
   /// <summary>
   /// Runs the BuildTailwind target and prints the output to the console.
   /// </summary>
   public static void RunTailwindBuild()
   {
      RunOnCommandLine("dotnet msbuild -target:BuildTailwind");
   }

   /// <summary>
   /// Runs the WatchTailwind target and prints the output to the console.
   /// </summary>
   public static void RunTailwindWatch()
   {
      RunOnCommandLine("dotnet msbuild -target:WatchTailwind");
   }

   private static void RunOnCommandLine(string command)
   {
      var process = new Process();
      process.StartInfo.FileName = "cmd.exe";
      process.StartInfo.RedirectStandardOutput = true;
      process.StartInfo.Arguments = $"/C {command} ";
      process.StartInfo.CreateNoWindow = false;
      process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
      process.StartInfo.UseShellExecute = false;
      process.Start();
      
      var output = process.StandardOutput.ReadToEnd();
      Console.WriteLine(output);
   }
}