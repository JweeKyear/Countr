using MvvmCross.Plugin.Messenger;
using System;
using System.Collections.Generic;
using System.Text;

namespace Countr.Core.Services
{
    public class CountersChangedMessage : MvxMessage
    {
        public CountersChangedMessage(object sender)
            : base(sender)
        { }
    }
}
