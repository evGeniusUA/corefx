// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Diagnostics;
using System;

namespace System.Diagnostics
{
    /// <devdoc>
    ///    <para>Provides a simple on/off switch that can be used to control debugging and tracing
    ///       output.</para>
    /// </devdoc>
    public class BooleanSwitch : Switch
    {
        /// <devdoc>
        /// <para>Initializes a new instance of the <see cref='System.Diagnostics.BooleanSwitch'/>
        /// class.</para>
        /// </devdoc>
        public BooleanSwitch(string displayName, string description)
            : base(displayName, description)
        {
        }

        public BooleanSwitch(string displayName, string description, string defaultSwitchValue)
            : base(displayName, description, defaultSwitchValue)
        { }

        /// <devdoc>
        ///    <para>Specifies whether the switch is enabled
        ///       (<see langword='true'/>) or disabled (<see langword='false'/>).</para>
        /// </devdoc>
        public bool Enabled
        {
            get
            {
                return (SwitchSetting == 0) ? false : true;
            }
            set
            {
                SwitchSetting = value ? 1 : 0;
            }
        }

        protected override void OnValueChanged()
        {
            bool b;
            if (Boolean.TryParse(Value, out b))
                SwitchSetting = (b ? 1 : 0);
            else
                base.OnValueChanged();
        }
    }
}

