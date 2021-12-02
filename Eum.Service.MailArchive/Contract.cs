using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Eum.Service.MailArchive
{
    internal static class Contract
    {
        private static int _instantIdentity = 0;
        private static int _logIdentity = 0;

        public static string InstanceIdentity => "I" + Interlocked.Increment(ref _instantIdentity);
        public static string LogIdentity => "L" + Interlocked.Increment(ref _logIdentity);
    }
}
