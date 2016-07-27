using Executor.Exceptions;
using System.Diagnostics;
using Executor.Network;

namespace Executor.IO.Commands
{
    public class OpenFileCommand : Command
    {
        public OpenFileCommand(string input, string[] data, Tester judge, StudentsRepository repository, DownloadManager downloadManager, IOManager inputOutputManager)
            : base(input, data, judge, repository, downloadManager, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string fileName = this.Data[1];
                Process.Start(SessionData.currentPath + "\\" + fileName);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
