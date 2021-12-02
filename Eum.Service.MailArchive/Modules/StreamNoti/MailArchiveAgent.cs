using Eum.Service.MailArchive.Core;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eum.Service.MailArchive.Modules.StreamNoti
{
    public interface IMailArchiveAgent
    {
        void Start();
        void Stop();
    }

    public class MailArchiveAgent : IMailArchiveAgent
    {
        private ILog _log;
        private StreamNotiConfig _config;

        public MailArchiveAgent(StreamNotiConfig config)
        {
            _log = ContainerResolver.Logger("ApprovalManager");
            _config = config;
        }

        public void Start()
        {
            _log.Info("-------------------------------------------------------------------------------");
            _log.Info($"{nameof(Start)}()");
            var mailboxes = _config.Mailboxes;
        }

        public void Stop()
        {
            _log.Info($"{nameof(Stop)}()");
        }
    }
}
