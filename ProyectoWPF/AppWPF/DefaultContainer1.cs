using System;

namespace AppWPF
{
    internal class DefaultContainer
    {
        private Uri uri;

        public DefaultContainer(Uri uri)
        {
            this.uri = uri;
        }

        public object People { get; internal set; }
    }
}