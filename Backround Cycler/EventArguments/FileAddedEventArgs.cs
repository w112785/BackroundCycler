/*
Copyright (c) 2006-2008, William Edward McCormick

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.Diagnostics;

namespace Backround_Cycler.EventArguments
{
    [DebuggerStepThrough ()]
    class FileAddedEventArgs : EventArgs
    {
        protected string _FilePath;
        protected string[] _Files;
        /// <summary>
        /// Gets the file path.
        /// </summary>
        /// <value>The file path.</value>
        public string FilePath { get { return _FilePath; } }
        public string[] GetFiles { get { return _Files; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileAddedEventArgs"/> class.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public FileAddedEventArgs ( string filePath )
            : base ()
        {
            _FilePath = filePath;
        }

        public FileAddedEventArgs ( string[] files )
        {
            _Files = files;
        }
    }

    [DebuggerStepThrough ()]
    class FileRemovedEventArgs : FileAddedEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileRemovedEventArgs"/> class.
        /// </summary>
        /// <param name="file">The file.</param>
        public FileRemovedEventArgs ( string file ) : base ( file ) { }
    }
}
