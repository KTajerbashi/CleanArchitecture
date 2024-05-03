using Design.Pattern.Library.Facade.SubSystem.DatabaseBackup;
using Design.Pattern.Library.Facade.SubSystem.DrawContainer;
using Design.Pattern.Library.Facade.SubSystem.EmailContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Pattern.Library.Facade.Pattern
{
    public interface IFacadContainer
    {
        IBackupRepository BackupRepository { get; }
        IEmailRepository EmailRepository { get; }
        IDrawRepository DrawRepository { get; }
    }
}
