﻿using System;

namespace VSPropertyPages
{
    public class ProjectPropertyChangingEventArgs : EventArgs
    {
        public string PropertyName { get; }

        public ProjectPropertyChangingEventArgs(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}
