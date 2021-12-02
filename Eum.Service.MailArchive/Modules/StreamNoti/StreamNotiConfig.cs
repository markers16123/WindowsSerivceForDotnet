using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eum.Service.MailArchive.Modules.StreamNoti
{
    public class StreamNotiConfig
    {
        /// <summary>
        /// 아카이빙 대상 메일주소 목록을 가져옵니다.
        /// </summary>
        public IEnumerable<string> Mailboxes => Convert.ToString(
            ConfigurationManager.AppSettings["Mailboxes"])?.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
            // default
            ?? new string[] { };

        public string TenantId => Convert.ToString(
            ConfigurationManager.AppSettings["TenantId"]);

        public string AppId => Convert.ToString(
            ConfigurationManager.AppSettings["AppId"]);

        public string Secret => Convert.ToString(
            ConfigurationManager.AppSettings["Secret"]);
    }
}
