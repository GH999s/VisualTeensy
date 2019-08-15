﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using vtCore.Interfaces;

namespace vtCore
{
    public class Configuration : IConfiguration
    {
        public SetupTypes setupType { get; set; }

        public string name { get; set; }
        public string guid { get; set; }
             
        // boards.txt --------------------------------
     //   public string boardTxtPath { get; set; }
        //public string boardTxtPathError => (!String.IsNullOrWhiteSpace(boardTxtPath) && File.Exists(boardTxtPath)) ? null : "Error";
        //public bool copyBoardTxt { get; set; }


        // compilerBase ------------------------------
        public CheckedPath compilerBase { get; } = new CheckedPath("bin\\arm-none-eabi-gcc.exe");

        // core --------------------------------------
        public CheckedPath coreBase { get; } = new CheckedPath("Arduino.h");     
        public bool copyCore { get; set; }
        public bool localCore { get; set; }
        public string core => Path.Combine(coreBase.path, "cores", selectedBoard.core);

        // makefile  ------------------------
        public string makefile { get; set; }
        public string makefileExtension { get; set; }
        
        // libraries ---------------------------------
        public List<IProjectLibrary> sharedLibs { get; set; }
        public List<IProjectLibrary> localLibs { get; set; }
        
        // boards
        public List<IBoard> boards { get; private set; }
        public IBoard selectedBoard { get; set; }

        public Configuration(SetupData settings = null)
        {
          //  this.setup = settings;
            boards = new List<IBoard>();
            sharedLibs = new List<IProjectLibrary>();
            localLibs = new List<IProjectLibrary>();
            guid = Guid.NewGuid().ToString();
        }
   
        public void logProject()
        {
            var sb = new StringBuilder();
            sb.Append("Data:\n");
            sb.Append($"setupType:\t{setupType}\n");           
            //sb.Append($"boardTxtPath:\t{boardTxtPath}\n");
            sb.Append($"compilerBase:\t{compilerBase}\n");
            sb.Append($"coreBase:\t{coreBase}\n");
            sb.Append($"selectedBoard:\t{selectedBoard?.name}");
            //log.Debug(sb.ToString());
        }

        public static IConfiguration getDefault(SetupData setupData)
        {
            //log.Info("enter");
            var pd = new Configuration(setupData)
            {
                setupType = SetupTypes.quick,
                name = "default",                      
            };

            pd.boards = new List<IBoard>();
            pd.coreBase.path = setupData.arduinoCoreBase;
            pd.compilerBase.path = setupData.arduinoCompiler;
            pd.parseBoardsTxt(setupData.arduinoBoardsTxt);
            pd.logProject();

            return pd;
        }

        public void parseBoardsTxt(string bt)
        {
            //log.Info("enter");

            string btp = bt ?? Path.Combine(coreBase.path, "boards.txt");
                       
            //  var vboards = BoardsTxt.parse(bt ?? boardTxtPath);
            var vboards = BoardsTxt.parse(btp);

            ProjectTransferData.vtBoard tmp = new ProjectTransferData.vtBoard(selectedBoard);
            //  boards = BoardsTxt.parse(bt ?? boardTxtPath).Where(b => b.core == "teensy3" || b.core == "teensy4").ToList();
            boards = BoardsTxt.parse(btp).Where(b => b.core == "teensy3" || b.core == "teensy4").ToList();
            setBoardOptions(tmp);
        }

        private void setBoardOptions(ProjectTransferData.vtBoard boardInfo)
        {
            selectedBoard = boards?.FirstOrDefault(b => b.name == boardInfo.name) ?? boards?.FirstOrDefault();
            if (selectedBoard != null)
            {
                if (boardInfo.options != null)
                {
                    foreach (var option in boardInfo.options)
                    {
                        var optionSet = selectedBoard.optionSets.FirstOrDefault(x => x.name == option.Key);
                        if (optionSet != null)
                        {
                            optionSet.selectedOption = optionSet.options.FirstOrDefault(x => x.name == option.Value);
                        }
                    }
                }
            }            
        }
                     

        //private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    }
}

