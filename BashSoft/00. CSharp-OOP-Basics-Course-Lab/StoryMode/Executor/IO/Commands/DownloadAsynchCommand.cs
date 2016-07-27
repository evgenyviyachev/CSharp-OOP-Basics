﻿using Executor.Exceptions;
using Executor.Network;

namespace Executor.IO.Commands
{
    public class DownloadAsynchCommand : Command
    {
        public DownloadAsynchCommand(string input, string[] data, Tester judge, StudentsRepository repository, DownloadManager downloadManager, IOManager inputOutputManager)
            : base(input, data, judge, repository, downloadManager, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string url = this.Data[1];
                this.DownloadManager.DownloadAsync(url);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}