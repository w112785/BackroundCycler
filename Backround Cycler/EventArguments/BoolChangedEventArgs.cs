/*
Copyright (c) 2007-2008, William Edward McCormick

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.Diagnostics;

namespace Backround_Cycler.EventArguments
{
    [DebuggerStepThrough ()]
    public class BoolChangedEventArgs : EventArgs
    {
        private bool _Enabled;
        /// <summary>
        /// Gets a value indicating whether this <see cref="BoolChangedEventArgs"/> 
        /// is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        public bool Enabled
        {
            get { return _Enabled; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BoolChangedEventArgs"/> class.
        /// </summary>
        /// <param name="enabled">is the <c>bool</c> value <c>true</c></param>
        public BoolChangedEventArgs ( bool enabled )
            : base ()
        {
            _Enabled = enabled;
        }
    }
}
