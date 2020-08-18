﻿using Newtonsoft.Json;
using System.Collections.Generic;
using vtCore.Interfaces;

namespace vtCore
{
    static class DebugFile_vsCode
    {
        static public string generate(IProject project, SetupData setup)
        {
            IConfiguration cfg = project.selectedConfiguration;
            if (cfg.selectedBoard == null) return "ERROR, no board selected";

            (string target, string svd) = DebugFile.seggerDebugTargets.TryGetValue(cfg.selectedBoard.id, out (string, string) value) ? value : ("unknown", "unknown");
            ////string compilerBase = (cfg.setupType == SetupTypes.quick ? setup.arduinoCompiler : cfg.compilerBase.shortPath)??"Error".Replace('\\', '/');
            string compilerBase = cfg.compiler;

            var launchJson = new
            {
                version = "0.2.0",
                configurations = new[]
                {                  
                  new
                  {
                      name = "Teensy Debug - LAUNCH",
                      cwd = "${workspaceRoot}",
                      executable = ".vsteensy/build/" + project.cleanName +".elf",
                      request = "launch",
                      type = "gdb",
                      servertype = "jlink",
                      device = target,                    
                      armToolchainPath= cfg.compiler,
                  },
                }
            };


            return JsonConvert.SerializeObject(launchJson, Formatting.Indented);
        }
    }
}
