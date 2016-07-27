using Executor.Exceptions;
using Executor.Network;
using System;

namespace Executor.IO.Commands
{
    public abstract class Command
    {
        private string input;
        private string[] data;
        private Tester judge;
        private StudentsRepository repository;
        private DownloadManager downloadManager;
        private IOManager inputOutputManager;

        public Command(string input, string[] data, Tester judge, StudentsRepository repository, DownloadManager downloadManager, IOManager inputOutputManager)
        {
            this.Input = input;
            this.Data = data;
            this.judge = judge;
            this.repository = repository;
            this.downloadManager = downloadManager;
            this.inputOutputManager = inputOutputManager;
        }

        public string Input
        {
            get
            {
                return this.input;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.input = value;
            }
        }

        protected string[] Data
        {
            get
            {
                return this.data;
            }
            private set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException();
                }

                this.data = value;
            }
        }

        protected Tester Judge { get; }
        protected StudentsRepository Repository { get; }
        protected DownloadManager DownloadManager { get; }
        protected IOManager InputOutputManager { get; }

        public abstract void Execute();
    }    
}
