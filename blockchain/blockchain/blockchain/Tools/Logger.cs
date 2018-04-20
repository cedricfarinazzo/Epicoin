using System.Collections.Generic;

namespace blockchain
{
    public class Logger
    {
        protected List<string> buffer;
        protected int bufferlenght = 20;

        public Logger()
        {
            this.buffer = new List<string>();
        }

        public void Write(string log)
        {
            this.buffer.Add(log);
            if (this.buffer.Count > this.bufferlenght)
            {
                this.buffer.RemoveAt(0);
            }
        }

        public string Read()
        {
            string log = "";
            foreach (var message in this.buffer)
            {
                log += message + "\n";
            }

            return log;
        }

        public string pop()
        {
            string text = Read();
            this.buffer.Clear();
            return text;
        }
    }
}